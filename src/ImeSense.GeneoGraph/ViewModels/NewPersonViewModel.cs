using System;
using System.Linq;
using System.Reactive;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels;

public class NewPersonViewModel : ReactiveObject {
    public NewPersonViewModel() {
        AddPersonCommand = ReactiveCommand.Create(AddPerson);
    }

    [Reactive]
    public bool GenderMale { get; set; }

    [Reactive]
    public bool GenderFemale { get; set; }

    [Reactive]
    public string SelectedGender { get; set; } = "Unknown";

    [Reactive]
    public string? FirstName { get; set; }

    [Reactive]
    public string? LastName { get; set; }

    [Reactive]
    public string? Patronym { get; set; }

    [Reactive]
    public string? MaidenName { get; set; }

    [Reactive]
    public bool IsDeceased { get; set; } = false;

    [Reactive]
    public DateTime BirthDate { get; set; }

    [Reactive]
    public string? BirthPlace { get; set; }

    [Reactive]
    public DateTime DeathDate { get; set; }

    [Reactive]
    public string? DeathPlace { get; set; }

    [Reactive]
    public string? DeathCause { get; set; }

    [Reactive]
    public string? BurialPlace { get; set; }
    private void GenderSelector() {
        if (GenderMale == true) {
            SelectedGender = "Male";
        } else if (GenderFemale == true) {
            SelectedGender = "Female";
        } else {
            SelectedGender = "Unknown";
        }
    }

    public void AddPerson() {
        GenderSelector();
        FirstName ??= "Unknown";
        AddPerson(SelectedGender, FirstName, LastName, Patronym, MaidenName, IsDeceased, BirthDate, BirthPlace, DeathDate, DeathPlace, DeathCause, BurialPlace);
        AddPersonClose();

    }

       public static void AddPerson(string gender, string firstname, string? lastname, string? patronym, string? maidenname,
    bool isDeceased, DateTime birthdate, string? birthplace, DateTime deathdate, string? deathplace, string? deathcause, string? burialplace) {
        var list = Person.PeopleList;
        var newID = list?.Last().Id + 1;
        list?.Add(new Person() {
            Id = newID ?? 0,
            Gender = gender,
            FirstName = firstname,
            LastName = lastname,
            Patronym = patronym,
            MaidenName = maidenname,
            IsDeceased = isDeceased,
            BirthDate = birthdate,
            BirthPlace = birthplace,
            DeathDate = deathdate,
            DeathPlace = deathplace,
            DeathCause = deathcause,
            BurialPlace = burialplace
        });
    }

    public IReactiveCommand<Unit, Unit> AddPersonCommand { get; set; }
    public IReactiveCommand<Unit, Unit> AddPersonCloseCommand { get; set; } = ReactiveCommand.Create(AddPersonClose);


    public static void AddPersonClose() {
        FamilyTreeViewModel.AddPersonClose();
    }
}
