using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using STB_desktop;

namespace STB_desktop.Services
{
    public class BaseApiService<T>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _endpoint;

       
        public BaseApiService(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<List<T>>(_endpoint);
                return items ?? new List<T>();
            }
            catch (HttpRequestException)
            {
                return new List<T>();
            }
        }

        public async Task<bool> CreateAsync(T item)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_endpoint, item);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException) { return false; }
        }

        public async Task<bool> UpdateAsync(Guid id, T item)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{_endpoint}/{id}", item);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException) { return false; }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException) { return false; }
        }
    }
}
