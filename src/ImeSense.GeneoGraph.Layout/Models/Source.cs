using System;
using System.Collections.ObjectModel;

namespace ImeSense.GeneoGraph.Layout.Models;

public class Source {
    public int SourceId { get; set; }
    public string SourceName { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public string? SourceDescription { get; set; } = string.Empty;
    public string? SourceURL { get; set; } = string.Empty;
    public Location? SourceLocation { get; set; }
    public string? SourceAuthor { get; set;} = string.Empty;
    public string? SourcePublisher { get; set; } = string.Empty;
    public DateTime SourceAddedDate { get; set; } = DateTime.Today;

    public override string ToString() {
        return SourceName;
    }

    public static ObservableCollection<Source> ListSources { get; set; } = new() 
    {
        new Source {
            SourceId = 1,
            SourceName = "Source1",
            SourceType = "Test",
            SourceDescription = "test desc",
        },
        new Source {
            SourceId = 2,
            SourceName = "Source2",
            SourceType = "Test 2",
            SourceDescription = "test desc 2",
        },
        new Source {
            SourceId = 3,
            SourceName = "Source3",
            SourceType = "Test 3",
            SourceDescription = "test desc 3",
        },
    };
}
