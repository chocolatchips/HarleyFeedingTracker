using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Services
{
    public interface IHarleyServices
    {
        Task<bool> GetIsFedAsync();
        Task<FeedItem> GetIsFedItemAsync();
        Task ChangeIsFedAsync();
    }
}
