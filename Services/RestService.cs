using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace HarleyFeedingTracker.Services
{
    public class RestService
    {
        private const string morning = "harley/morning";
        private Uri baseUri = new("https://www.sheard.ca");
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }


        public async Task<string> GetFedAsync()
        {
            Uri uri = new(baseUri, morning);

            try
            {
                HttpResponseMessage res = _client.GetAsync(uri).Result;
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    return content;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return uri.ToString();
        }

    }
}
