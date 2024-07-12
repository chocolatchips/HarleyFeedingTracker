using HarleyFeedingTracker.Models;
using static HarleyFeedingTracker.Constants.ApiConstants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;



namespace HarleyFeedingTracker.Services
{
    public class RestService : IRestService
    {   
        readonly HttpClient _client;
        readonly JsonSerializerOptions _serializerOptions;


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
            Uri uri = TimeOfDayUri();

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
            Uri uri = TimeOfDayUri();

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
        }

        public async Task<bool> UpdateFedAsync()
        {
            Uri uri = TimeOfDayUri();
            try
            {

                HttpResponseMessage response = _client.PostAsync(uri, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    FeedItem res = JsonSerializer.Deserialize<FeedItem>(content)!;
                    return res.IsFed;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;

            throw new NotImplementedException();
        }

        private Uri TimeOfDayUri()
        {
            DateTime date = DateTime.Now;
            Uri uri;
            if (date.Hour >= 12)
                return uri = new(BaseUri, Evening);
            else
                return uri = new(BaseUri, Morning);
        }
    }
}
