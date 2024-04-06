using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Design.Models {
    public class Education 
    {
        public int Id { get; set; }

        public string EducationPlace { get; set; }
        public string? EducationNotes { get; set; }

        public DateTime? EducationDateFrom { get; set; }
        public DateTime? EducationDateRange { get; set; } ///Used only if <see cref="EducationDateFrom" /> is set to "Between" and we need a date range
        public string EducationDateFromType { get; set; } = "Exact";

        public DateTime? EducationDateTo { get; set; } ///Used only if <see cref="EducationDateTo" /> is set to "Between" and we need a date range
        public DateTime? EducationDateToRange { get; set; }
        public string EducationDateToType { get; set; } = "Exact";

    }
}
