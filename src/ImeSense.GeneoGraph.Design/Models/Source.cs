using System;

namespace ImeSense.GeneoGraph.Design.Models;

public class Source {
    public int SourceId { get; set; }
    public string SourceName { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public string SourceDescription { get; set; } = string.Empty;
    public string SourceURL { get; set; } = string.Empty;
    public Location? SourceLocation { get; set; }
    public string SourceAuthor { get; set;} = string.Empty;
    public string SourcePublisher { get; set; } = string.Empty;
    public DateTime SourceAddedDate { get; set; } = DateTime.Today;

    public override string ToString() {
        return SourceName;
    }
}
