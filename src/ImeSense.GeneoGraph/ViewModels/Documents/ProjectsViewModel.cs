using Dock.Model.ReactiveUI.Controls;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class ProjectsViewModel : Document {
    private string? _path;

    public string? Path {
        get => _path;
        set => this.RaiseAndSetIfChanged(ref _path, value);
    }
}
