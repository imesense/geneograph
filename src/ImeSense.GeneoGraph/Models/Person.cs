using System;
using System.Collections.ObjectModel;
using System.Linq;

using ImeSense.GeneoGraph.ViewModels;

namespace ImeSense.GeneoGraph.Models;

public class Person {
    public int Id { get; set; }

    public string FirstName { get; set; } = "Unknown";

    public string? LastName { get; set; }

    public string? Patronim { get; set; }

    public string? MaidenName { get; set; }

    public string? Gender { get; set; }

    public bool IsDeceased { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? BirthPlace { get; set; }

    public DateTime? DeathDate { get; set; }

    public string? DeathPlace { get; set; }


    /// <summary>
    /// Should be calculated based on <see cref="BirthDate" />
    /// and <see cref="DeathDate" /> date
    /// </summary>
    public int Age { get; set; }
    public override string ToString() => FullName;

    public string FullName => $"{Id}. {FirstName} {LastName}";

    public static ObservableCollection<Person> People => new() {
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
        },
    };

    public static void AddPerson(string gender, string firstname, string lastname,
        bool isDeceased, DateTime birthdate, DateTime deathdate) {
        var newID = People.Last().Id + 1;
        People.Add(new Person() {
            Id = newID,
            Gender = gender,
            FirstName = firstname,
            LastName = lastname,
            IsDeceased = isDeceased,
            BirthDate = birthdate,
            DeathDate = deathdate,
        });
    }
}
