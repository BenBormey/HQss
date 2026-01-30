using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace unt_bingoo.Controller
{
    public class APIsController
    {
        private readonly HttpClient _client;
        private string _token;

        public APIsController()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5189/"),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        // ================= TOKEN =================

        public bool HasToken()
        {
            return !string.IsNullOrEmpty(_token);
        }

        private void SetToken(string token)
        {
            _token = token;

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public void Logout()
        {
            _token = null;
            _client.DefaultRequestHeaders.Authorization = null;
        }

        // ================= LOGIN =================

        private class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class LoginResponse
        {
            public string access_token { get; set; }
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

                var res = await PostAsync<LoginResponse>(
                    "api/auth/login", req);

                if (res == null || string.IsNullOrEmpty(res.access_token))
                    return false;

                SetToken(res.access_token);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error:\n" + ex.Message);
                return false;
            }
        }

        // ================= SAFE WRAPPER =================

        private async Task<T> SafeCall<T>(Func<Task<T>> action)
        {
            try
            {
                return await action();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timeout!");
                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API Error:\n" + ex.Message);
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
                MessageBox.Show("API Error:\n" + ex.Message);
                return false;
            }
        }

        // ================= GENERIC =================

        // GET
        public Task<T> GetAsync<T>(string url)
        {
            return SafeCall(async () =>
            {
                var res = await _client.GetAsync(url);

                var json = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw new Exception(json);

                return JsonConvert.DeserializeObject<T>(json);
            });
        }

        // POST (return data)
        public Task<T> PostAsync<T>(string url, object body)
        {
            return SafeCall(async () =>
            {
                var json = JsonConvert.SerializeObject(body);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var res = await _client.PostAsync(url, content);

                var rjson = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw new Exception(rjson);

                return JsonConvert.DeserializeObject<T>(rjson);
            });
        }

        // POST (bool)
        public Task<bool> PostAsync(string url, object body)
        {
            return SafeCall(async () =>
            {
                var json = JsonConvert.SerializeObject(body);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var res = await _client.PostAsync(url, content);

                return res.IsSuccessStatusCode;
            });
        }

        // PUT
        public Task<bool> PutAsync(string url, object body)
        {
            return SafeCall(async () =>
            {
                var json = JsonConvert.SerializeObject(body);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var res = await _client.PutAsync(url, content);

                return res.IsSuccessStatusCode;
            });
        }

        // DELETE
        public Task<bool> DeleteAsync(string url)
        {
            return SafeCall(async () =>
            {
                var res = await _client.DeleteAsync(url);

                return res.IsSuccessStatusCode;
            });
        }
    }
}
