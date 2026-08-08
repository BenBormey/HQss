using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unt_bingoo.Diagnostics
{
    /// <summary>
    /// Last-resort net for exceptions that get past every local try/catch in the app.
    /// Call Install() once, before Application.Run, and before anything else that
    /// could throw during startup.
    /// </summary>
    public static class GlobalExceptionHandler
    {
        private static int _handling; // 0/1 guard against a handler re-entering itself

        public static void Install()
        {
            // Without this, WinForms shows its own "Unhandled exception" dialog for
            // UI-thread exceptions and never raises Application.ThreadException at all.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
                HandleSafely(e.Exception, CrashSource.UiThread);

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                HandleSafely(e.ExceptionObject as Exception, CrashSource.NonUiThread);

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                HandleSafely(e.Exception, CrashSource.BackgroundTask);
                e.SetObserved();
            };
        }

        private static void HandleSafely(Exception ex, CrashSource source)
        {
            // If logging or the message box itself throws, do not recurse back in here.
            if (Interlocked.Exchange(ref _handling, 1) == 1)
                return;

            try
            {
                var severity = ExceptionClassifier.Classify(ex, source);
                string outcome;
                string userMessage = null;

                switch (severity)
                {
                    case CrashSeverity.Fatal:
                        outcome = "Fatal - application exiting";
                        userMessage = ExceptionClassifier.FatalMessage;
                        break;

                    case CrashSeverity.RestartRequired:
                        outcome = "RestartRequired - application closing";
                        userMessage = ExceptionClassifier.RestartRequiredMessage;
                        break;

                    case CrashSeverity.Recoverable:
                    default:
                        outcome = "Recoverable - application continues";
                        // Background task faults are shown to no one - the user never
                        // waited on this operation, so a popup would be a non sequitur.
                        userMessage = source == CrashSource.BackgroundTask ? null : ExceptionClassifier.RecoverableMessage;
                        break;
                }

                CrashLogger.Log(ex, source, severity, outcome);

                if (userMessage != null)
                {
                    try
                    {
                        MessageBox.Show(userMessage, "JuJuBi Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch
                    {
                        // A MessageBox can itself fail if the UI thread is already in a bad
                        // state - the log entry above is what matters, not the dialog.
                    }
                }

                if (severity == CrashSeverity.RestartRequired)
                {
                    Application.Exit();
                }
                else if (severity == CrashSeverity.Fatal)
                {
                    Environment.Exit(1);
                }
                // Recoverable: fall through and let the app keep running.
            }
            finally
            {
                Interlocked.Exchange(ref _handling, 0);
            }
        }
    }
}
