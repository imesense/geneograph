using System.Collections.ObjectModel;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Layout.Models;

public class NoteCategory {
    public int Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public override string ToString() {
        return CategoryName;
    }

    [Reactive]
    public static ObservableCollection<NoteCategory> CategoryList { get; set; } = new() {
        new NoteCategory {
            Id = 1,
            CategoryName = "Custom1",
        },
        new NoteCategory {
            Id = 2,
            CategoryName = "Custom2",
        },
        new NoteCategory {
            Id = 3,
            CategoryName = "Custom3",
        },
    };
}
