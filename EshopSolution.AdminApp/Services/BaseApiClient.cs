using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EshopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EshopSolution.AdminApp.Services
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                    typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
        //protected async Task<TResponse> PostAsync<TResponse>(string url, StringContent content)
        //{
        //    var sessions = _httpContextAccessor
        //        .HttpContext
        //        .Session
        //        .GetString(SystemConstants.AppSettings.Token);

        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
        //    var response = await client.PostAsync(url, content);
        //    var body = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
        //            typeof(TResponse));

        //        return myDeserializedObjList;
        //    }
        //    return JsonConvert.DeserializeObject<TResponse>(body);}
        protected async Task<List<TResponse>> GetListAsync<TResponse>(string url, bool requiredLogin = true)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<TResponse>)JsonConvert.DeserializeObject(body, typeof(List<TResponse>));
                return data;
            }
            throw new Exception(body);
        }

    }

}
