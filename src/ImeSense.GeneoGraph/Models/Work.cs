using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Models {
    public class Work 
    {
        public int Id { get; set; }

        public string? CompanyName { get; set; }
        public string? Occupation { get; set; }
        public string? WorkNotes { get; set; }

        public DateTime? WorkDateFrom { get; set; }
        public DateTime? WorkDateRange { get; set; } ///Used only if <see cref="WorkDateFrom" /> is set to "Between" and we need a date range
        public string WorkDateFromType { get; set; } = "Exact";

        public DateTime? WorkDateTo { get; set; } ///Used only if <see cref="WorkDateTo" /> is set to "Between" and we need a date range
        public DateTime? WorkDateToRange { get; set; }
        public string WorkDateToType { get; set; } = "Exact";
    }
}
