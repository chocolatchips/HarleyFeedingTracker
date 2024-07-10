using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Services
{
    public interface IRestService
    {
        public Task<bool> GetFedAsync();
        public Task<FeedItem> GetFedItemAsync();
        public Task<bool> UpdateFedAsync();
    }
}
