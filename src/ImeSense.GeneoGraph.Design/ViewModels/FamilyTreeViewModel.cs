using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Design.Models;
using ImeSense.GeneoGraph.Design.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels;

public class FamilyTreeViewModel : ReactiveObject {
    private static Window? _addPersonWindow;
    private bool _sidebarStatus = false;
    private bool _sidebarButtonVisibility = true;
    private Person? _selectedPerson;
    private int _selectedPersonIndex;

    public FamilyTreeViewModel() {
        PeopleGender = new() {
            "Male", "Female", "Unknown",
        };

        PeopleList = Person.PeopleList;

        SideBarOpenCloseCommand = ReactiveCommand.Create(SideBarOpenClose);

        this.WhenAnyValue(x => x.SelectedPersonIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index >= 0)
            .Subscribe(_ => SidebarStatus = true);

        this.WhenAnyValue(x => x.SelectedPersonIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index < 0)
            .Subscribe(_ => SidebarStatus = false);

        this.WhenAnyValue(x => x.SelectedPersonIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index >= 0)
            .Subscribe(_ => SidebarButtonVisibility = false);

        this.WhenAnyValue(x => x.SelectedPersonIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index < 0)
            .Subscribe(_ => SidebarButtonVisibility = true);

        SidebarStatus = false;
        SelectedPerson = null;
    }

    public List<string> PeopleGender { get; set; }

    [Reactive]
    public bool SidebarStatus {
        get => _sidebarStatus;
        set => this.RaiseAndSetIfChanged(ref _sidebarStatus, value);
    }

    public bool SidebarButtonVisibility {
        get => _sidebarButtonVisibility;
        set => this.RaiseAndSetIfChanged(ref _sidebarButtonVisibility, value);
    }

    [Reactive]
    public ObservableCollection<Person>? PeopleList { get; set; }

    [Reactive]
    public Person? SelectedPerson {
        get => _selectedPerson;
        set => this.RaiseAndSetIfChanged(ref _selectedPerson, value);
    }

    [Reactive]
    public int SelectedPersonIndex {
        get => _selectedPersonIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedPersonIndex, value);
    }

    public IReactiveCommand<Unit, Unit> AddPersonOpenCommand { get; set; } = ReactiveCommand.Create(AddPersonOpen);
    public IReactiveCommand<Unit, Unit> AddPersonCloseCommand { get; set; } = ReactiveCommand.Create(AddPersonClose);
    public IReactiveCommand<Unit, Unit> SideBarOpenCloseCommand { get; set; }

    public static void AddPersonOpen() {
        _addPersonWindow = new AddPersonWindow();
        _addPersonWindow.Show();
    }

    public static void AddPersonClose() {
        _addPersonWindow?.Close();
    }

    public void SideBarOpenClose() {
        if (SidebarStatus == false && SelectedPerson == null) {
            SelectedPerson = PeopleList?.FirstOrDefault();
            SidebarStatus = true;
            SidebarButtonVisibility = false;
        } else if (SidebarStatus == false) {
            SidebarStatus = true;
            SidebarButtonVisibility = false;
        } else {
            SidebarStatus = false;
            SidebarButtonVisibility = true;
        }
    }
}
