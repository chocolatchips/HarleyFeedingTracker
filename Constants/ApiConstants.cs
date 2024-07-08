using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Constants
{
    class ApiConstants
    {
        private static readonly string apiStart = "api/harley/";
        private static readonly string morning = "morning";
        private static readonly string evening = "evening";

        public static string Morning { get { return apiStart + morning; } }
        public static string Evening { get { return apiStart + evening; } }
        

#if DEBUG
        public static string LocalHostUrl = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string Scheme = "http";
        public static string Port = "3000";
        public static Uri BaseUri = new($"{Scheme}://{LocalHostUrl}:{Port}");
#else
        public static Uri BaseUri = new("https://www.sheard.ca");
#endif

    }
}
