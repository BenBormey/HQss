using System;

namespace unt_bingoo.Diagnostics
{
    /// <summary>
    /// How bad a crash is, and what the app should do about it.
    /// Recoverable  - log it, tell the user, keep the app running (the form that faulted may be in a bad state, but the app process is fine).
    /// RestartRequired - something on the UI thread went wrong in a way that leaves shared state unreliable; log it, tell the user, then close.
    /// Fatal        - the CLR itself is compromised (OOM, stack overflow, corrupted image); log what we can and exit immediately.
    /// </summary>
    public enum CrashSeverity
    {
        Recoverable,
        RestartRequired,
        Fatal
    }

    /// <summary>Where the exception was caught, since that says more about blast radius than the exception type does.</summary>
    public enum CrashSource
    {
        UiThread,
        BackgroundTask,
        NonUiThread
    }

    public static class ExceptionClassifier
    {
        public const string RestartRequiredMessage =
            "Something went wrong and this program needs to close.\n\nYour recent changes may not have been saved. Please reopen the program and check before continuing.";

        public const string RecoverableMessage =
            "Something went wrong with that action, but the program can keep running.\n\nPlease check your data before continuing.";

        public const string FatalMessage =
            "A serious error occurred and the program must close immediately.";

        /// <summary>
        /// Exception types that mean the CLR/process itself is no longer trustworthy,
        /// regardless of which thread raised them.
        /// </summary>
        private static bool IsAlwaysFatal(Exception ex)
        {
            return ex is OutOfMemoryException
                || ex is StackOverflowException
                || ex is AccessViolationException
                || ex is AppDomainUnloadedException
                || ex is BadImageFormatException
                || ex is InvalidProgramException
                || ex is TypeLoadException
                || ex is System.Runtime.InteropServices.SEHException;
        }

        public static CrashSeverity Classify(Exception ex, CrashSource source)
        {
            if (ex != null && IsAlwaysFatal(ex))
                return CrashSeverity.Fatal;

            switch (source)
            {
                case CrashSource.NonUiThread:
                    // An exception that reached AppDomain.UnhandledException is, by definition,
                    // one nothing on the stack was prepared to handle. The CLR terminates the
                    // process right after this fires regardless of what we do, so there is no
                    // "recover and continue" option here.
                    return CrashSeverity.Fatal;

                case CrashSource.BackgroundTask:
                    // An unobserved Task exception does not take the process down on its own.
                    // Log it and move on rather than interrupt the user for something they
                    // never waited on in the first place.
                    return CrashSeverity.Recoverable;

                case CrashSource.UiThread:
                default:
                    // NullReferenceException / InvalidOperationException / InvalidCastException
                    // here mean some shared static/global state (APIGlobals, Initialized, a
                    // cached grid data source) is now in a shape the rest of the app does not
                    // expect. Continuing risks writing bad data through APIsController, so the
                    // safe default is to close, not to keep going.
                    return CrashSeverity.RestartRequired;
            }
        }
    }
}
