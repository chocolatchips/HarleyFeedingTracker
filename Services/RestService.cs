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
            DateTime date = DateTime.Now;
            Uri uri;
            if (date.Hour >= 12)
                uri = new(BaseUri, Evening);
            else
                uri = new(BaseUri, Morning);
            
            try
            {
                HttpResponseMessage res = _client.GetAsync(uri).Result;
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    FeedItem fed = JsonSerializer.Deserialize<FeedItem>(content)!;
                    return fed.IsFed;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        public async Task<FeedItem> GetFedItemAsync()
        {
            DateTime date = DateTime.Now;
            Uri uri;
            if (date.Hour >= 12)
                uri = new(BaseUri, Evening);
            else
                uri = new(BaseUri, Morning);

            try
            {
                HttpResponseMessage res = _client.GetAsync(uri).Result;
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    FeedItem feed = JsonSerializer.Deserialize<FeedItem>(content)!;
                    return feed;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new FeedItem();
            //throw new NotImplementedException();
        }

        public Task<bool> UpdateFedAsync()
        {

            throw new NotImplementedException();
        }
    }
}
