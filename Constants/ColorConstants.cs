using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Constants
{
    internal class ColorConstants
    {
        private static readonly List<Color> chartColors = [Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Purple];
        public static List<Color> ChartColors { get { return chartColors; } }
    }
}
