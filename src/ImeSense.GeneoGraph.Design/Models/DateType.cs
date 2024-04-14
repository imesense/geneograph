using System.Collections.ObjectModel;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.Models;

public class DateType {
    public string TypeName { get; set; } = string.Empty;

    [Reactive]
    public ObservableCollection<DateType> DateTypeList { get; set; } = new() {
        new DateType {
            TypeName = "Exactly",
        },
        new DateType {
            TypeName = "Before",
        },
        new DateType {
            TypeName = "After",
        },
        new DateType {
            TypeName = "Circa",
        },
        new DateType {
            TypeName = "Between",
        },
    };
}
