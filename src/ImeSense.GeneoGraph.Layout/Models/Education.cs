using System;

namespace ImeSense.GeneoGraph.Layout.Models;

public class Education {
    public int Id { get; set; }

    public string EducationPlace { get; set; } = string.Empty;
    public string? EducationNotes { get; set; }

    public DateTime? EducationDateFrom { get; set; }
    public DateTime? EducationDateRange { get; set; } ///Used only if <see cref="EducationDateFrom" /> is set to "Between" and we need a date range
    public string EducationDateFromType { get; set; } = "Exact";

    public DateTime? EducationDateTo { get; set; } ///Used only if <see cref="EducationDateTo" /> is set to "Between" and we need a date range
    public DateTime? EducationDateToRange { get; set; }
    public string EducationDateToType { get; set; } = "Exact";
}
