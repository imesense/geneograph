using Dock.Model.ReactiveUI.Controls;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class FileViewModel : Document {
    private string? _path = string.Empty;

    public string? Path {
        get => _path;
        set => this.RaiseAndSetIfChanged(ref _path, value);
    }
}
