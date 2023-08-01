using Dock.Model.Mvvm.Controls;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class FileViewModel : Document {
    private string? _path = string.Empty;

    public string? Path {
        get => _path;
        set => SetProperty(ref _path, value);
    }
}
