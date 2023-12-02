using System;
using System.Linq;
using System.Reactive;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels;

public class NewPersonViewModel : ReactiveObject {

    public NewPersonViewModel() {
        AddPersonCommand = ReactiveCommand.Create(AddPerson);
    }

    private bool _gendermale;
    private bool _genderfemale;

    private string _selectedgender = "Unknown";
    private string? _firstname;
    private string? _lastname;
    private string? _patronym;
    private string? _maidenname;

    private bool _isdeceased = false;

    private DateTime _birthdate;
    private string? _birthplace;

    private DateTime _deathdate;
    private string? _deathplace;
    private string? _deathcause;
    private string? _burialplace;

    public bool GenderMale {
        get => _gendermale;
        set => this.RaiseAndSetIfChanged(ref _gendermale, value);
    }

    public bool GenderFemale {
        get => _genderfemale;
        set => this.RaiseAndSetIfChanged(ref _genderfemale, value);
    }

    public string SelectedGender {
        get => _selectedgender;
        set => this.RaiseAndSetIfChanged(ref _selectedgender, value);
    }

    public string? FirstName {
        get => _firstname;
        set => this.RaiseAndSetIfChanged(ref _firstname, value);
    }

    public string? LastName {
        get => _lastname;
        set => this.RaiseAndSetIfChanged(ref _lastname, value);
    }

    public string? Patronym {
        get => _patronym;
        set => this.RaiseAndSetIfChanged(ref _patronym, value);
    }

    public string? MaidenName {
        get => _maidenname;
        set => this.RaiseAndSetIfChanged(ref _maidenname, value);
    }

    public bool IsDeceased {
        get => _isdeceased;
        set => this.RaiseAndSetIfChanged(ref _isdeceased, value);
    }

    public DateTime BirthDate {
        get => _birthdate;
        set => this.RaiseAndSetIfChanged(ref _birthdate, value);
    }

    public string? BirthPlace {
        get => _birthplace;
        set => this.RaiseAndSetIfChanged(ref _birthplace, value);
    }

    public DateTime DeathDate {
        get => _deathdate;
        set => this.RaiseAndSetIfChanged(ref _deathdate, value);
    }


    public string? DeathPlace {
        get => _deathplace;
        set => this.RaiseAndSetIfChanged(ref _deathplace, value);
    }

    public string? DeathCause {
        get => _deathcause;
        set => this.RaiseAndSetIfChanged(ref _deathcause, value);
    }

    public string? BurialPlace {
        get => _burialplace;
        set => this.RaiseAndSetIfChanged(ref _burialplace, value);
    }


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
