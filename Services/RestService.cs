using HarleyFeedingTracker.Models;
using static HarleyFeedingTracker.Constants.ApiConstants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace HarleyFeedingTracker.Services
{
    public class RestService : IRestServices
    {   
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


        public async Task<bool> GetFedAsync()
        {
            Uri uri = new(BaseUri, Morning);
            
            try
            {
                HttpResponseMessage res = _client.GetAsync(uri).Result;
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    FedItem fed = JsonSerializer.Deserialize<FedItem>(content)!;
                    return fed.IsFed;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        public async Task<bool> UpdateFedAsync()
        {

            throw new NotImplementedException();
        }
    }
}
