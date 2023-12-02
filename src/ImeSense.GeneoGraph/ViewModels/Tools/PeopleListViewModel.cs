using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

using Avalonia.Controls;

using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels.Tools;

public class PeopleListViewModel : Tool {
    private static Window? _addPersonWindow;

    public PeopleListViewModel() {
        PeopleSex = new() {
            "Male", "Female", "Unknown",
        };

        PeopleList = new ObservableCollection<Person> {
        new Person() {
            Id = 1,
            Gender = "Male",
            FirstName = "Nikita",
            LastName = "Lebedin",
            IsDeceased = false,
            BirthDate = new DateTime(1998,03,03),
            BirthPlace = "Kharkov, Ukraine",
        },
        new Person() {
            Id = 2,
            Gender = "Male",
            FirstName = "Vasiliy",
            LastName = "Petrov",
            IsDeceased = true,
            BirthDate = new DateTime(1898,01,01),
            DeathDate = new DateTime(1975,01,07),
            BirthPlace = "Unknown"
        },
        new Person() {
            Id = 3,
            Gender = "Female",
            FirstName = "Anna",
            LastName = "Aristova",
            IsDeceased = true,
            BirthDate = new DateTime(1888,12,12),
            BirthPlace = "Somewhere"

        },
        new Person() {
            Id = 4,
            Gender = "Male",
            FirstName = "Ivan",
            LastName = "Vanov",
            IsDeceased = false,
            BirthDate = new DateTime(1765,05,23),
            BirthPlace = "Mukhosransk"
        },
        new Person() {
            Id = 5,
            Gender = "Female",
            FirstName = "Fiona",
            LastName = "Shrekova",
            IsDeceased = true,
            BirthDate = new DateTime(1856,02,13),
            BirthPlace = "Gradograd, Hochland"
        }};
    }

    public List<string> PeopleSex { get; set; }

    public static ObservableCollection<Person> PeopleList { get; set; } = new();

    [Reactive]
    public Person? SelectedPerson { get; set; }

    [Reactive]
    public int SelectedIndex { get; set; }

    public IReactiveCommand<Unit, Unit> AddPersonOpenCommand { get; set; } = ReactiveCommand.Create(AddPersonOpen);
    public IReactiveCommand<Unit, Unit> AddPersonCloseCommand { get; set; } = ReactiveCommand.Create(AddPersonClose);
    public IReactiveCommand<Unit, Unit> AddPersonUpdateCommand { get; set; } = ReactiveCommand.Create(AddPersonUpdate);

    public static void AddPersonOpen() {
        _addPersonWindow = new NewPerson();
        _addPersonWindow.Show();
    }

    public static void AddPersonClose() {
        _addPersonWindow?.Close();
    }

    public static void AddPersonUpdate() {
        PeopleList.Clear();
    }
}
