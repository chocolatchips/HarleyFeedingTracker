using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Models
{
    [Table("feedingdetails")]
    public class FeedingDetails
    {
        [Column("brand")]
        public string? Brand {  get; set; }

        [Column("flavour")]
        public string? Flavour { get; set; }

        [Column("treat")]
        public string? Treat { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }
    }
}
