using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Services
{
    interface IRestServices
    {
        public Task<bool> GetFedAsync();
        public Task<bool> UpdateFedAsync();
    }
}
