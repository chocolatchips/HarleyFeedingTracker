﻿using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Services
{
    public class HarleyServices : IHarleyServices
    {
        RestService _restService;
        public HarleyServices()
        {
            _restService = new RestService();
        }

        public Task<bool> ChangeIsFedAsync()
        {
            return _restService.UpdateFedAsync();
        }

        public Task<bool> GetIsFedAsync()
        {
            return _restService.GetFedAsync();
        }

        public Task<FeedItem> GetIsFedItemAsync()
        {
            return _restService.GetFedItemAsync();
        }
    }
}
