using System;
using unt_bingoo.Diagnostics;

namespace unt_bingoo.Tests
{
    /// <summary>
    /// CrashLogger.FormatEntry is what actually ends up on disk when something
    /// goes wrong - these check the fields a human debugging a crash later
    /// actually needs are present, and that a missing exception object or a
    /// deep inner-exception chain can't make formatting itself throw.
    /// </summary>
    public class CrashLoggerTests
    {
        [Fact]
        public void Includes_source_severity_and_outcome()
        {
            var entry = CrashLogger.FormatEntry(
                new InvalidOperationException("bad state"),
                CrashSource.UiThread,
                CrashSeverity.RestartRequired,
                "RestartRequired - application closing");

            Assert.Contains("Source:   UiThread", entry);
            Assert.Contains("Severity: RestartRequired", entry);
            Assert.Contains("Outcome:  RestartRequired - application closing", entry);
        }

        [Fact]
        public void Includes_exception_type_and_message()
        {
            var entry = CrashLogger.FormatEntry(
                new InvalidOperationException("bad state"),
                CrashSource.UiThread,
                CrashSeverity.RestartRequired,
                "RestartRequired - application closing");

            Assert.Contains("System.InvalidOperationException", entry);
            Assert.Contains("bad state", entry);
        }

        [Fact]
        public void Includes_the_stack_trace_when_present()
        {
            Exception thrown;
            try
            {
                throw new InvalidOperationException("bad state");
            }
            catch (Exception ex)
            {
                thrown = ex;
            }

            var entry = CrashLogger.FormatEntry(thrown, CrashSource.UiThread, CrashSeverity.RestartRequired, "outcome");

            Assert.Contains("Stack trace:", entry);
            Assert.Contains(nameof(Includes_the_stack_trace_when_present), entry);
        }

        [Fact]
        public void Includes_inner_exception_details()
        {
            var inner = new ArgumentNullException("outletId");
            var outer = new InvalidOperationException("wrapper", inner);

            var entry = CrashLogger.FormatEntry(outer, CrashSource.BackgroundTask, CrashSeverity.Recoverable, "outcome");

            Assert.Contains("Inner[0]:", entry);
            Assert.Contains("ArgumentNullException", entry);
        }

        [Fact]
        public void Does_not_throw_for_a_null_exception()
        {
            var entry = CrashLogger.FormatEntry(null, CrashSource.NonUiThread, CrashSeverity.Fatal, "Fatal - application exiting");

            Assert.Contains("(null exception)", entry);
            Assert.Contains("Fatal - application exiting", entry);
        }

        [Fact]
        public void Different_entries_do_not_collide_on_content()
        {
            var a = CrashLogger.FormatEntry(new Exception("A"), CrashSource.UiThread, CrashSeverity.RestartRequired, "outcome-a");
            var b = CrashLogger.FormatEntry(new Exception("B"), CrashSource.BackgroundTask, CrashSeverity.Recoverable, "outcome-b");

            Assert.NotEqual(a, b);
        }
    }
}
