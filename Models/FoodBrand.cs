using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Models
{
    [Table("brands")]
    public class FoodBrand
    {
        [PrimaryKey]
        [Column("brand")]
        public string? Name { get; set; }
    }
}
