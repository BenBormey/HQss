using System;
using System.Runtime.InteropServices;
using unt_bingoo.Diagnostics;

namespace unt_bingoo.Tests
{
    /// <summary>
    /// Covers the actual decision table in ExceptionClassifier.Classify, not
    /// just "it returns something". A wrong classification here means either
    /// the app keeps running after something that should have stopped it, or
    /// closes on something harmless - both are real user-facing regressions.
    /// </summary>
    public class ExceptionClassifierTests
    {
        [Theory]
        [InlineData(CrashSource.UiThread)]
        [InlineData(CrashSource.BackgroundTask)]
        [InlineData(CrashSource.NonUiThread)]
        public void OutOfMemory_is_always_fatal_regardless_of_source(CrashSource source)
        {
            Assert.Equal(CrashSeverity.Fatal, ExceptionClassifier.Classify(new OutOfMemoryException(), source));
        }

        [Theory]
        [InlineData(CrashSource.UiThread)]
        [InlineData(CrashSource.BackgroundTask)]
        [InlineData(CrashSource.NonUiThread)]
        public void AccessViolation_is_always_fatal_regardless_of_source(CrashSource source)
        {
            Assert.Equal(CrashSeverity.Fatal, ExceptionClassifier.Classify(new AccessViolationException(), source));
        }

        [Fact]
        public void StackOverflow_is_fatal()
        {
            Assert.Equal(CrashSeverity.Fatal, ExceptionClassifier.Classify(new StackOverflowException(), CrashSource.UiThread));
        }

        [Fact]
        public void BadImageFormat_is_fatal()
        {
            Assert.Equal(CrashSeverity.Fatal, ExceptionClassifier.Classify(new BadImageFormatException(), CrashSource.UiThread));
        }

        [Fact]
        public void SEHException_is_fatal()
        {
            Assert.Equal(CrashSeverity.Fatal, ExceptionClassifier.Classify(new SEHException(), CrashSource.UiThread));
        }

        [Theory]
        [InlineData(typeof(NullReferenceException))]
        [InlineData(typeof(InvalidOperationException))]
        [InlineData(typeof(InvalidCastException))]
        public void Ordinary_programming_errors_on_the_UI_thread_are_never_classified_recoverable(Type exceptionType)
        {
            var ex = (Exception)Activator.CreateInstance(exceptionType);

            var severity = ExceptionClassifier.Classify(ex, CrashSource.UiThread);

            // These mean shared static state (APIGlobals, etc.) may now be
            // inconsistent - "keep going as if nothing happened" is not safe.
            Assert.NotEqual(CrashSeverity.Recoverable, severity);
            Assert.Equal(CrashSeverity.RestartRequired, severity);
        }

        [Fact]
        public void An_unhandled_exception_on_a_non_UI_thread_is_fatal()
        {
            // Reaching AppDomain.UnhandledException at all means nothing on the
            // stack was prepared to handle it; the CLR is about to terminate the
            // process regardless of what this method returns.
            var severity = ExceptionClassifier.Classify(new InvalidOperationException("boom"), CrashSource.NonUiThread);

            Assert.Equal(CrashSeverity.Fatal, severity);
        }

        [Fact]
        public void A_background_task_fault_is_recoverable_so_the_app_keeps_running()
        {
            var severity = ExceptionClassifier.Classify(new InvalidOperationException("boom"), CrashSource.BackgroundTask);

            Assert.Equal(CrashSeverity.Recoverable, severity);
        }

        [Fact]
        public void A_null_exception_object_does_not_throw_and_still_classifies_by_source()
        {
            // AppDomain.UnhandledException.ExceptionObject is only guaranteed to be
            // an object, not an Exception - Classify must tolerate a null/non-Exception
            // ExceptionObject rather than NullReferenceException inside the handler itself.
            var severity = ExceptionClassifier.Classify(null, CrashSource.BackgroundTask);

            Assert.Equal(CrashSeverity.Recoverable, severity);
        }
    }
}
