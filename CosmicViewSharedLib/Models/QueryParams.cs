using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicViewSharedLib.Models
{
    public class QueryParams
    {
        public string? Date { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int? Count { get; set; }
        public bool Thumbs { get; set; }
    }
}
