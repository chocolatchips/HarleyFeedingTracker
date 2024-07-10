using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Models
{
    [Table("brandflavours")]
    public class FlavourItem
    {
        public string? Brand {  get; set; }
        public string? Flavour {  get; set; }
    }
}
