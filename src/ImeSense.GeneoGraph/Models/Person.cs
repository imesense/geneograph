using System;
using System.Collections.ObjectModel;
using System.Linq;

using ImeSense.GeneoGraph.ViewModels;

namespace ImeSense.GeneoGraph.Models;

public class Person {
    public int Id { get; set; }

    public string FirstName { get; set; } = "Unknown";

    public string? LastName { get; set; }

    public string? Patronym { get; set; }

    public string? MaidenName { get; set; }

    public string? Gender { get; set; }

    public bool IsDeceased { get; set; } = false;

    public DateTime? BirthDate { get; set; }

    public string? BirthPlace { get; set; }

    public DateTime? DeathDate { get; set; }

    public string? DeathPlace { get; set; }
    public string? DeathCause { get; set; }
    public string? BurialPlace { get; set; }


    /// <summary>
    /// Should be calculated based on <see cref="BirthDate" />
    /// and <see cref="DeathDate" /> date
    /// </summary>
    public int? Age => GetAge(IsDeceased, BirthDate, DeathDate);

    public static int? GetAge(bool isdeceased, DateTime? birthdate, DateTime? deathdate) 
    {
        if (birthdate == null) 
        { 
            return null;
        }
        else if (isdeceased == false) 
        {
            return DateTime.Now.AddTicks(0 - birthdate.GetValueOrDefault(DateTime.Now).Ticks).Year - 1; ;
        }
        else if (isdeceased == true && deathdate == null)
        {
            return null;
        }
        else        
        {
            return deathdate.GetValueOrDefault(DateTime.Now).AddTicks(0 - birthdate.GetValueOrDefault(DateTime.Now).Ticks).Year - 1;
        }
    }

    public override string ToString() => FullName;

    public string FullName => $"{FirstName} {LastName}";

    public static ObservableCollection<Person>? PeopleList = new() {
        new Person() {
            Id = 1,
            Gender = "Male",
            FirstName = "Nikita",
            LastName = "Lebedin",
            IsDeceased = false,
            BirthDate = new DateTime(1998,03,03),
            BirthPlace = "Kharkov, Ukraine"
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

    public static ObservableCollection<Person> GetPeople () {
        return PeopleList;
    }


    public static void AddPerson() {
        PeopleList.Add(new Person() {
            Id = 1,
            Gender = "Male",
            FirstName = "Nikita",
            LastName = "Lebedin",
            IsDeceased = false,
            BirthDate = new DateTime(1998, 03, 03),
            BirthPlace = "Kharkov, Ukraine"
        });
    }
}
