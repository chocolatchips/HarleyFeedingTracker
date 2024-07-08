using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Services
{
    public interface IHarleyServices
    {
        //Task<bool> GetIsFedAsync();
        Task<string> GetIsFedAsync();
        Task ChangeIsFedAsync();
    }
}
