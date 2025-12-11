using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using unt_bingoo.Class;

namespace unt_bingoo.Controller
{
    public class APIsController
    {
        private readonly HttpClient _client;

        public APIsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7098/");
        }

        public async Task<List<CurrencyItem>> GetCurrencyAsync()
        {
            var res = await _client.GetAsync("api/currency");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CurrencyItem>>(json);
            return data ?? new List<CurrencyItem>();
        }

        public async Task<CurrencyItem> GetCurrencyByIdAsync(int id)
        {
            var res = await _client.GetAsync($"api/currency/{id}");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CurrencyItem>(json);
            return data;
        }

        public async Task<bool> AddCurrencyAsync(CurrencyItem model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/currency", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCurrencyAsync(int id, CurrencyItem model)
        {
            if (id != model.Id) return false;

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/currency/{id}", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCurrencyAsync(int id)
        {
            var res = await _client.DeleteAsync($"api/currency/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<List<CategoryItem>> GetCategoryAsync()
        {
            var res = await _client.GetAsync("api/category");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<CategoryItem>>(json);
            return data ?? new List<CategoryItem>();
        }

        public async Task<CategoryItem> GetCategoryByIdAsync(int id)
        {
            var res = await _client.GetAsync($"api/category/{id}");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CategoryItem>(json);
            return data;
        }

        public async Task<bool> AddCategoryAsync(CategoryItem model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/category", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryItem model)
        {
            if (id != model.Id) return false;

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/category/{id}", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var res = await _client.DeleteAsync($"api/category/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<List<BranchItem>> GetBrandAsync()
        {
            var res = await _client.GetAsync("api/Brand");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<BranchItem>>(json);
            return data ?? new List<BranchItem>();
        }

        public async Task<BranchItem> GetBrandByIdAsync(int id)
        {
            var res = await _client.GetAsync($"api/Brand/{id}");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<BranchItem>(json);
            return data;
        }

        public async Task<bool> AddBrandAsync(BranchItem model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/Brand", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBrandAsync(int id, BranchItem model)
        {
            if (id != model.Id) return false;

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/Brand/{id}", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var res = await _client.DeleteAsync($"api/Brand/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<List<BranchItem>> GetBranchAsync()
        {
            var res = await _client.GetAsync("api/Brand");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<BranchItem>>(json);
            return data ?? new List<BranchItem>();
        }

        public async Task<BranchItem> GetBranchByIdAsync(int id)
        {
            var res = await _client.GetAsync($"api/Brand/{id}");
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<BranchItem>(json);
            return data;
        }

        public async Task<bool> AddBranchAsync(BranchItem model)
        {
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PostAsync("api/Brand", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBranchAsync(int id, BranchItem model)
        {
            if (id != model.Id) return false;

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await _client.PutAsync($"api/Brand/{id}", content);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBranchAsync(int id)
        {
            var res = await _client.DeleteAsync($"api/Brand/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
