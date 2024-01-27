using Dock.Model.ReactiveUI.Controls;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class FileViewModel : Document {
    [Reactive]
    public string? Path { get; set; }
}
