using System;
using System.IO;
using System.Text;

namespace unt_bingoo.Diagnostics
{
    /// <summary>
    /// Writes crash/exception entries to %LocalAppData%\JuJuBiAdmin\logs\crash-yyyy-MM-dd.log
    /// and prunes files older than 30 days. Deliberately has no dependency on
    /// APIsController/APIGlobals or any other app code, so a broken login/API
    /// state can never take logging down with it.
    /// </summary>
    public static class CrashLogger
    {
        private const int RetentionDays = 30;
        private static string _logDirectory;
        private static readonly object SyncRoot = new object();

        public static void Initialize()
        {
            try
            {
                _logDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "JuJuBiAdmin", "logs");

                Directory.CreateDirectory(_logDirectory);
                PruneOldLogs();
            }
            catch
            {
                // Logging must never be the reason the app fails to start.
                _logDirectory = null;
            }
        }

        private static void PruneOldLogs()
        {
            if (string.IsNullOrEmpty(_logDirectory) || !Directory.Exists(_logDirectory))
                return;

            var cutoff = DateTime.Now.AddDays(-RetentionDays);
            foreach (var file in Directory.GetFiles(_logDirectory, "crash-*.log"))
            {
                try
                {
                    if (File.GetLastWriteTime(file) < cutoff)
                        File.Delete(file);
                }
                catch
                {
                    // Best effort - a locked/undeletable old file is not worth failing startup over.
                }
            }
        }

        public static void Log(Exception ex, CrashSource source, CrashSeverity severity, string outcome)
        {
            try
            {
                if (string.IsNullOrEmpty(_logDirectory))
                    return;

                var path = Path.Combine(_logDirectory, $"crash-{DateTime.Now:yyyy-MM-dd}.log");
                var entry = FormatEntry(ex, source, severity, outcome);

                lock (SyncRoot)
                {
                    File.AppendAllText(path, entry, Encoding.UTF8);
                }
            }
            catch
            {
                // Never let a logging failure escalate into a second crash.
            }
        }

        internal static string FormatEntry(Exception ex, CrashSource source, CrashSeverity severity, string outcome)
        {
            var sb = new StringBuilder();
            sb.AppendLine(new string('=', 70));
            sb.AppendLine($"Time:     {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
            sb.AppendLine($"Source:   {source}");
            sb.AppendLine($"Severity: {severity}");
            sb.AppendLine($"Outcome:  {outcome}");
            sb.AppendLine();

            if (ex == null)
            {
                sb.AppendLine("Type:    (null exception)");
            }
            else
            {
                sb.AppendLine($"Type:    {ex.GetType().FullName}");
                sb.AppendLine($"Message: {ex.Message}");
                sb.AppendLine("Stack trace:");
                sb.AppendLine(string.IsNullOrEmpty(ex.StackTrace) ? "  (none)" : ex.StackTrace);

                var inner = ex.InnerException;
                var depth = 0;
                while (inner != null && depth < 5)
                {
                    sb.AppendLine($"Inner[{depth}]: {inner.GetType().FullName}: {inner.Message}");
                    inner = inner.InnerException;
                    depth++;
                }
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}
