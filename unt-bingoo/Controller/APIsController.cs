using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using unt_bingoo.Class;

namespace unt_bingoo.Controller
{
    public class APIsController
    {
        private const string ConfigFileName = "appsettings.json";

        private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(30);
        private readonly HttpClient _client;
        private readonly HttpClient _externalClient;

        private string _token;

        public APIsController()
        {
            var apiBaseUrl = ResolveApiBaseUrl(GetConfigPath());

            if (apiBaseUrl == null)
            {
                throw new InvalidOperationException(
                    "The API server address is not configured.\n\n" +
                    "Set \"ApiBaseUrl\" in appsettings.json (next to the application .exe) to a valid http:// or https:// address, then restart.");
            }

            _client = new HttpClient
            {
                BaseAddress = new Uri(apiBaseUrl),
                Timeout = RequestTimeout
            };

            _externalClient = new HttpClient
            {
                Timeout = RequestTimeout
            };
            _externalClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        }

        private static string GetConfigPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigFileName);
        }

        /// <summary>
        /// Reads ApiBaseUrl from appsettings.json. Pure function (no HttpClient/UI
        /// side effects) so it can be exercised directly by tests. Returns null for
        /// every failure mode (missing file, malformed JSON, missing/blank key,
        /// unusable value) rather than guessing a host - deliberately no hardcoded
        /// production IP or localhost fallback here; the caller decides what an
        /// unconfigured server means for the app.
        /// </summary>
        internal static string ResolveApiBaseUrl(string configPath)
        {
            try
            {
                if (string.IsNullOrEmpty(configPath) || !File.Exists(configPath))
                    return null;

                var json = File.ReadAllText(configPath);
                var root = JObject.Parse(json);
                var value = root["ApiBaseUrl"]?.ToString();

                if (string.IsNullOrWhiteSpace(value))
                    return null;

                value = value.Trim();

                if (!Uri.TryCreate(value, UriKind.Absolute, out var uri))
                    return null;

                if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
                    return null;

                if (!value.EndsWith("/"))
                    value += "/";

                return value;
            }
            catch
            {
                return null;
            }
        }


        private void SetToken(string token)
        {
            _token = token;

       
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            APIGlobals.Token = token;
        }

        public void Logout()
        {
            _token = null;

            _client.DefaultRequestHeaders.Authorization = null;

            APIGlobals.UserId = 0;
            APIGlobals.OutletId = 0;
            APIGlobals.Token = null;
            APIGlobals.RoleCode = null;
            APIGlobals.Permissions = new List<string>();
        }

        public bool HasToken()
        {
            return !string.IsNullOrEmpty(_token);
        }

      
        private class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class MdLoginRequest
        {
            public string Password { get; set; }
        }

        private class LoginResponse
        {
            public string access_token { get; set; }
            public UserInfo user { get; set; }
        }

        private class UserInfo
        {
            public int id { get; set; }
            public int? outletId { get; set; }
            public string username { get; set; }
            public string fullName { get; set; }
            public string roleName { get; set; }
            public string roleCode { get; set; }
        }

        public async Task<bool> LoginAsync(string user, string pass)
        {
            try
            {
                var req = new LoginRequest
                {
                    Username = user,
                    Password = pass
                };

                var res = await PostAsync<LoginResponse>("api/auth/login", req);

                if (res == null || string.IsNullOrEmpty(res.access_token))
                    return false;

                SetToken(res.access_token);

                APIGlobals.UserId = res.user.id;
                APIGlobals.OutletId = res.user.outletId;
                APIGlobals.UserName = res.user.username;
                APIGlobals.FullName = res.user.fullName;
                APIGlobals.RoleName = res.user.roleName;
                APIGlobals.RoleCode = res.user.roleCode;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error:\n" + ex.Message);
                return false;
            }
        }

        public async Task<bool> MdLoginAsync(string password)
        {
            try
            {
                var req = new MdLoginRequest
                {
                    Password = password
                };

                var res = await PostAsync<LoginResponse>("api/auth/md-login", req);

                if (res == null || string.IsNullOrEmpty(res.access_token))
                    return false;

                SetToken(res.access_token);

                APIGlobals.UserId = res.user.id;
                APIGlobals.OutletId = res.user.outletId;
                APIGlobals.UserName = res.user.username;
                APIGlobals.FullName = res.user.fullName;
                APIGlobals.RoleName = res.user.roleName;
                APIGlobals.RoleCode = res.user.roleCode;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error:\n" + ex.Message);
                return false;
            }
        }

        public Task<UserItem> GetMeAsync()
        {
            return GetAsync<UserItem>("api/users/me");
        }

        public async Task<string> GetNextSupplierCodeAsync()
        {
            var res = await GetAsync<JObject>("api/Supplier/next-code");
            return res?["supplierCode"]?.ToString();
        }

        public async Task<string> GetNextRoleCodeAsync()
        {
            var res = await GetAsync<JObject>("api/role/next-code");
            return res?["roleCode"]?.ToString();
        }

        // ---------------------------------------------------------
        //  PERMISSIONS
        // ---------------------------------------------------------
        public Task<List<PermissionItem>> GetPermissionsAsync()
        {
            return GetAsync<List<PermissionItem>>("api/permission");
        }

        public Task<List<int>> GetRolePermissionIdsAsync(int roleId)
        {
            return GetAsync<List<int>>($"api/permission/role/{roleId}");
        }

        public Task<bool> SaveRolePermissionsAsync(int roleId, List<int> permissionIds)
        {
            return PutAsync($"api/permission/role/{roleId}", permissionIds);
        }

        public async Task<List<string>> GetMyPermissionsAsync()
        {
            return await GetAsync<List<string>>("api/permission/my") ?? new List<string>();
        }

        // The md-login/login response doesn't include HasSystemAccess, so
        // look the logged-in user up in the full user list to check it.
        public async Task<bool> HasSystemAccessAsync(int userId)
        {
            var users = await GetAsync<List<UserItem>>("api/users") ?? new List<UserItem>();
            var match = users.FirstOrDefault(u => u.Id == userId);

            // If the lookup fails for some reason, don't lock the user out over it.
            return match?.HasSystemAccess ?? true;
        }

        private async Task<T> SafeCall<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout! Server មិនឆ្លើយតបក្នុង 30 វិនាទី។");
                return default;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }
        private async Task<bool> SafeCall(Func<Task<bool>> action)
        {
            try
            {
                return await action();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout!");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
        }

        // ---------------------------------------------------------
        //  GENERIC HTTP METHODS (internal API)
        // ---------------------------------------------------------
        public Task<T> GetAsync<T>(string url)
        {
            return SafeCall(async () =>
            {
                var res = await _client.GetAsync(url);

                // 404 on a GET-by-key lookup means "doesn't exist yet", which
                // every caller of this method already treats as a normal,
                // valid outcome (e.g. "if (existing != null)" duplicate
                // checks) — not an error worth popping a MessageBox for.
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return default;

                var json = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw new Exception(json);

                return JsonConvert.DeserializeObject<T>(json);
            });
        }

        public Task<T> PostAsync<T>(string url, object body)
        {
            return SafeCall(async () =>
            {
                var json = JsonConvert.SerializeObject(body);

                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var res = await _client.PostAsync(url, content);
                    var rjson = await res.Content.ReadAsStringAsync();

                    if (!res.IsSuccessStatusCode)
                        throw new Exception(rjson);

                    return JsonConvert.DeserializeObject<T>(rjson);
                }
            });
        }

        public Task<bool> PostAsync(string url, object body)
        {
            return SafeCall(async () =>
            {
                var json = JsonConvert.SerializeObject(body);

                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var res = await _client.PostAsync(url, content);

                    if (!res.IsSuccessStatusCode)
                    {
                        var err = await res.Content.ReadAsStringAsync();
                        MessageBox.Show(err);
                    }

                    return res.IsSuccessStatusCode;
                }
            });
        }

        public async Task<bool> PutAsync(string url, object body)
        {
            try
            {
                var json = JsonConvert.SerializeObject(body);

                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var res = await _client.PutAsync(url, content);

                    if (!res.IsSuccessStatusCode)
                    {
                        var error = await res.Content.ReadAsStringAsync();
                        throw new Exception($"API Error: {error}");
                    }

                    return true;
                }
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("Request timeout or canceled. Please check API server.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Network error while calling API.", ex);
            }
        }

        public async Task<bool> PatchAsync(string url, object body = null)
        {
            try
            {
                HttpResponseMessage res;

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), url);

                if (body != null)
                {
                    var json = JsonConvert.SerializeObject(body);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                res = await _client.SendAsync(request);

                if (!res.IsSuccessStatusCode)
                {
                    var error = await res.Content.ReadAsStringAsync();
                    throw new Exception($"API Error: {error}");
                }

                return true;
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("Request timeout or canceled. Please check API server.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Network error while calling API.", ex);
            }
        }

        public async Task<bool> DeleteAsync(string url)
        {
            return await SafeCall(async () =>
            {
                var response = await _client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                var content = await response.Content.ReadAsStringAsync();

                string message = "Delete failed.";

                if (!string.IsNullOrWhiteSpace(content))
                {
                    try
                    {
                        var json = JObject.Parse(content);

                        message = json["Message"]?.ToString()
                               ?? json["message"]?.ToString()
                               ?? message;
                    }
                    catch
                    {
                        message = content;
                    }
                }

                throw new Exception(message);
            });
        }

        public async Task<ExchangeRateResponse> GetNBCExchange()
        {
            return await SafeCall(async () =>
            {
                var res = await _externalClient.GetAsync("https://www.nbc.gov.kh/api/exRate.php");
                res.EnsureSuccessStatusCode();

                var xml = await res.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(xml);

                var items = doc.Descendants("ex")
                    .Select(x => new ExchangeRateItem
                    {
                        Date = x.Element("date")?.Value,
                        Key = x.Element("key")?.Value,
                        Unit = int.TryParse(x.Element("unit")?.Value, out var u) ? u : 0,
                        Bid = decimal.TryParse(x.Element("bid")?.Value, out var bid) ? bid : 0,
                        Ask = decimal.TryParse(x.Element("ask")?.Value, out var ask) ? ask : 0,
                        Average = decimal.TryParse(x.Element("average")?.Value, out var avg) ? avg : 0,
                    })
                    .ToList();

                return new ExchangeRateResponse
                {
                    ExternalSystemName = "NBC",
                    Items = items
                };
            });
        }

        public async Task<MefExchangeResponse> GetListByDate(DateTime date)
        {
            return await SafeCall(async () =>
            {
                string dateStr = date.ToString("yyyy-MM-dd");
                string url =
                    $"https://data.mef.gov.kh/api/v1/realtime-api/exchange-rate?currency_id=USD&date={dateStr}";

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");

                var res = await _externalClient.SendAsync(request);
                var json = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw new Exception($"MEF API Error: {json}");

                return JsonConvert.DeserializeObject<MefExchangeResponse>(json);
            });
        }

        public async Task<ProvinceResponse> GetProvincesAsync(int page = 1, int pageSize = 10)
        {
            return await SafeCall(async () =>
            {
                string url =
                    $"https://data.mef.gov.kh/api/v1/public-datasets/pd_66a8603700604c000123e144/json?page={page}&page_size={pageSize}";

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");

                var res = await _externalClient.SendAsync(request);
                var json = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw new Exception($"MEF Province API Error: {json}");

                return JsonConvert.DeserializeObject<ProvinceResponse>(json);
            });
        }
        public Task<string> UploadFileAsync(
       string url, byte[] fileBytes, string fileName, string formField = "file")
        {
            return SafeCall(async () =>
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType =
                        new MediaTypeHeaderValue(GuessContentType(fileName));

                    content.Add(fileContent, formField, fileName);

                    var res = await _client.PostAsync(url, content);

                    if (!res.IsSuccessStatusCode)
                    {
                        var err = await res.Content.ReadAsStringAsync();
                        MessageBox.Show(err);
                        return null;
                    }

                    var json = await res.Content.ReadAsStringAsync();

                    // Newtonsoft.Json
                    var result = JsonConvert.DeserializeObject<UploadResponse>(json);

                    return result?.ImageUrl;
                }
            });
        }
        private static string GuessContentType(string fileName)
        {
            switch (Path.GetExtension(fileName).ToLowerInvariant())
            {
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                case ".bmp": return "image/bmp";
                default: return "image/jpeg";
            }
        }
        
        // For loading a saved image back into the form
        public Task<byte[]> GetBytesAsync(string url)
        {
            return SafeCall(async () =>
            {
                var res = await _client.GetAsync(url);
                return res.IsSuccessStatusCode
                    ? await res.Content.ReadAsByteArrayAsync()
                    : null;
            });
        }

        // The same fetch, but silent: returns null instead of putting a modal
        // "Connection Error" box in front of the user.
        //
        // GetBytesAsync goes through SafeCall, which shows a MessageBox on
        // every failure. That is right for something the user just asked for
        // and wrong for a picture loading in the background — a product whose
        // image URL no longer resolves produced one dialog per attempt, and
        // opening a few products in a row buried the form under a stack of
        // them, none of which said which product it was about.
        //
        // A picture that will not load is a blank frame, not an interruption.
        public async Task<byte[]> TryGetBytesAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            try
            {
                using (var res = await _client.GetAsync(url))
                {
                    return res.IsSuccessStatusCode
                        ? await res.Content.ReadAsByteArrayAsync()
                        : null;
                }
            }
            catch
            {
                return null;
            }
        }

        // Turns whatever TPRProducts.ProImage happens to hold into a URL on the
        // API this client is actually pointed at.
        //
        // That column stores ABSOLUTE urls, so the host that was running when
        // the file was uploaded gets baked into the row. Ten of the eleven
        // products in this database still say http://localhost:5189/... — a
        // development server that is not running and is not reachable from any
        // other machine — so their images can never load as stored.
        //
        // Only the file name is durable. Re-basing it against ApiBaseUrl means
        // the images resolve wherever the client happens to point.
        public string ResolveImageUrl(string stored)
        {
            if (string.IsNullOrWhiteSpace(stored))
                return null;

            stored = stored.Trim();

            // Strip a query string before anything else: it is never part of
            // the stored file name and would break the lookup.
            int q = stored.IndexOf('?');
            if (q >= 0)
                stored = stored.Substring(0, q);

            // Keep only the last segment, which covers a bare file name (the
            // shape this column should hold), a stored relative path, and an
            // absolute URL pointing at a host that no longer exists.
            string name = stored.Split('/', '\\').LastOrDefault();

            return string.IsNullOrWhiteSpace(name)
                ? null
                : _client.BaseAddress.AbsoluteUri + "uploads/products/" + name;
        }

    }
    public class UploadResponse
    {
        public string ImageUrl { get; set; }
    }
}