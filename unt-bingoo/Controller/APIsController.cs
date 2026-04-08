using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

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
                Timeout = TimeSpan.FromMinutes(2)
            };
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
        }

    

        private class LoginRequest
        {
            public string Username { get; set; }
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
            public int outletId { get; set; }

            public string username { get; set; }
            public string fullName { get; set; }
            public string roleName { get; set; }
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

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error:\n" + ex.Message);
                return false;
            }
        }



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

                if (!res.IsSuccessStatusCode)
                {
                    var err = await res.Content.ReadAsStringAsync();
                    MessageBox.Show(err);
                }

                return res.IsSuccessStatusCode;
            });
        }



     public async Task<bool> PutAsync(string url, object body)
{
    try
    {
        var json = JsonConvert.SerializeObject(body);

        using (var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"))
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
      

        public Task<bool> DeleteAsync(string url)
        {
            return SafeCall(async () =>
            {
                var res = await _client.DeleteAsync(url);
                return res.IsSuccessStatusCode;
            });
        }
        public bool HasToken()
        {
            return !string.IsNullOrEmpty(_token);
        }

   
    }
}
