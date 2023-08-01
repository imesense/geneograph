using System.Collections.Generic;
using System.Collections.ObjectModel;

using Dock.Model.Mvvm.Controls;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.ViewModels;

public class PeopleListViewModel : Tool {
    private Person? _selectedPerson;
    private ObservableCollection<Person> _people = new();

    public PeopleListViewModel() {
        People = Person.People;
        PeopleSex = new() {
            "Male", "Female", "Unknown",
        };
    }

    public List<string> PeopleSex { get; set; }

    public Person? SelectedPerson {
        get => _selectedPerson;
        set => SetProperty(ref _selectedPerson, value);
    }

    public ObservableCollection<Person> People {
        get => _people;
        set => SetProperty(ref _people, value);
    }

    public static void AddPersonOpen() {
        NewPersonViewModel.AddPersonOpen();
    }
}
