using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

using Dock.Model.Controls;
using Dock.Model.Core;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ReactiveObject {
    private readonly IFactory? _factory;

    [Reactive]
    public IRootDock? Layout { get; set; }

    public Interaction<AddNoteViewModel, AddNoteReturnViewModel?> ShowDialog { get; }
    public ICommand AddNoteOpenCommand { get; }

    public MainViewModel() {
        _factory = new AppFactory();

        Layout = _factory?.CreateLayout();
        if (Layout is { }) {
            _factory?.InitLayout(Layout);
        }

        ShowDialog = new Interaction<AddNoteViewModel, AddNoteReturnViewModel?>();

        AddNoteOpenCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var store = new AddNoteViewModel();

            var result = await ShowDialog.Handle(store);
        });
    }

    public void CloseLayout() {
        if (Layout is IDock dock) {
            if (dock.Close.CanExecute(null)) {
                dock.Close.Execute(null);
            }
        }
    }
}
