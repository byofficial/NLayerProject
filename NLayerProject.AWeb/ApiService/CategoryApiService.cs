using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLayerProject.AWeb.DTOs;

namespace NLayerProject.AWeb.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync("categories");

            if (response.IsSuccessStatusCode)
            {
                categoryDtos =
                    JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());

            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;
        }

    }
}
