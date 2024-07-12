using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Constants
{
    class Text
    {
        private static readonly string harleyWasFed = "Harley has been fed.";
        private static readonly string harleyNotFed = "Harley has not been fed.";
        private static readonly string feedHarleyQuestion = "Do you want to feed Harley?";
        private static readonly string allDetails = "Get all details";
        private static readonly string detailsDatePicker = "Get details from date";

        public static string HarleyWasFed {  get { return harleyWasFed; } }
        public static string HarleyNotFed { get {return harleyNotFed; } }
        public static string FeedHarleyQuestion { get { return feedHarleyQuestion; } }
        public static string GetAllDetails { get { return allDetails; } }
        public static string DetailsDatePicker { get { return detailsDatePicker; } }
    }
}
