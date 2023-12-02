using Dock.Model.Controls;
using Dock.Model.Core;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ReactiveObject {
    private readonly IFactory? _factory;

    [Reactive]
    public IRootDock? Layout { get; set; }

    public MainViewModel() {
        _factory = new AppFactory();

        Layout = _factory?.CreateLayout();
        if (Layout is { }) {
            _factory?.InitLayout(Layout);
        }
    }

    public void CloseLayout() {
        if (Layout is IDock dock) {
            if (dock.Close.CanExecute(null)) {
                dock.Close.Execute(null);
            }
        }
    }
}
