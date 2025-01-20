using System;

namespace ImeSense.GeneoGraph.Layout.Models;

public class Partner {
    public int Id { get; set; }

    public Person Person { get; set; } = new Person();
    public string RelashionshipType { get; set; } = string.Empty;

    public DateTime? RelashionshipStartDate { get; set; }
    public DateTime? RelashionshipStartDateRange { get; set; }
    public DateType? RelationShipStartDateType { get; set; }

    public string? RelationshipPlace { get; set; }
    public string? Witnesses { get; set; }

    public DateTime? RelashionshipEndDate { get; set; }
    public DateTime? RelashionshipEndDateRange { get; set; }
    public DateType? RelationShipEndDateType { get; set; }
}
