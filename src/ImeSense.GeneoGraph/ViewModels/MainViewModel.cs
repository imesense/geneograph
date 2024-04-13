using Dock.Model.Controls;
using Dock.Model.Core;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ReactiveObject {
    private readonly IFactory? _factory;

    private IRootDock? _layout;

    public IRootDock? Layout {
        get => _layout;
        set => this.RaiseAndSetIfChanged(ref _layout, value);
    }

    public MainViewModel() {
        _factory = new AppFactory();

        Layout = _factory?.CreateLayout();
        if (Layout is { }) {
            _factory?.InitLayout(Layout);
        }
    }

    public void CloseLayout() {
        Layout?.Close.Execute(null);
        Layout = null;
    }
}
