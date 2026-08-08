using System;
using System.IO;
using unt_bingoo.Controller;

namespace unt_bingoo.Tests
{
    /// <summary>
    /// APIsController.ResolveApiBaseUrl replaced a hardcoded production IP
    /// (http://192.168.1.99:8099/) that required a rebuild to change. These
    /// cover every way appsettings.json can be wrong on a real machine: the
    /// method must never guess a host - it returns null and the caller (the
    /// APIsController constructor) refuses to start rather than silently
    /// talking to the wrong server.
    /// </summary>
    public class ApiBaseUrlTests : IDisposable
    {
        private readonly string _dir;

        public ApiBaseUrlTests()
        {
            _dir = Path.Combine(Path.GetTempPath(), "unt-bingoo-url-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_dir);
        }

        public void Dispose()
        {
            try { Directory.Delete(_dir, true); } catch { }
        }

        private string WriteConfig(string contents)
        {
            var path = Path.Combine(_dir, "appsettings.json");
            File.WriteAllText(path, contents);
            return path;
        }

        [Fact]
        public void Reads_the_configured_address()
        {
            var path = WriteConfig(@"{ ""ApiBaseUrl"": ""http://192.168.1.50:9000/"" }");

            Assert.Equal("http://192.168.1.50:9000/", APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Adds_the_trailing_slash_when_missing()
        {
            var path = WriteConfig(@"{ ""ApiBaseUrl"": ""http://192.168.1.50:9000"" }");

            Assert.Equal("http://192.168.1.50:9000/", APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Trims_surrounding_whitespace()
        {
            var path = WriteConfig("{ \"ApiBaseUrl\": \"  http://192.168.1.50:9000/  \" }");

            Assert.Equal("http://192.168.1.50:9000/", APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Accepts_https()
        {
            var path = WriteConfig(@"{ ""ApiBaseUrl"": ""https://api.jujubi.example/"" }");

            Assert.Equal("https://api.jujubi.example/", APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Returns_null_when_the_file_does_not_exist()
        {
            var missing = Path.Combine(_dir, "nope.json");

            Assert.Null(APIsController.ResolveApiBaseUrl(missing));
        }

        [Fact]
        public void Returns_null_when_the_json_is_malformed()
        {
            var path = WriteConfig("{ this is not json");

            Assert.Null(APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Returns_null_when_the_key_is_absent()
        {
            var path = WriteConfig(@"{ ""SomethingElse"": ""x"" }");

            Assert.Null(APIsController.ResolveApiBaseUrl(path));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("not-a-url")]
        public void Returns_null_for_unusable_values(string value)
        {
            var path = WriteConfig("{ \"ApiBaseUrl\": \"" + value + "\" }");

            Assert.Null(APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Returns_null_for_a_non_http_scheme()
        {
            // A typo like "htp://" or a non-web scheme must not silently become
            // a BaseAddress that every API call then fails against in a confusing way.
            var path = WriteConfig(@"{ ""ApiBaseUrl"": ""ftp://192.168.1.50/"" }");

            Assert.Null(APIsController.ResolveApiBaseUrl(path));
        }

        [Fact]
        public void Does_not_assume_localhost_when_unconfigured()
        {
            var path = WriteConfig(@"{ ""ApiBaseUrl"": """" }");

            var result = APIsController.ResolveApiBaseUrl(path);

            Assert.Null(result);
            Assert.DoesNotContain("localhost", result ?? string.Empty);
        }
    }
}
