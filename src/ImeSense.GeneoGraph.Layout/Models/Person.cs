using System;
using System.Collections.ObjectModel;

using Avalonia.Media.Imaging;

namespace ImeSense.GeneoGraph.Layout.Models;

public class Person {
    // Main Parameters
    public int Id { get; set; }

    public string FirstName { get; set; } = "Unknown";
    public string? LastName { get; set; }
    public string? Patronym { get; set; } //We can also use it for the Middle\Second name
    public string? MaidenName { get; set; }

    public string? Gender { get; set; }

    public bool IsDeceased { get; set; } = false;

    public string? Prefix { get; set; }
    public string? Suffix { get; set; }

    public int? Age => GetAge(IsDeceased, BirthDate, DeathDate);  //Calculated based on BirthDate and DeathDate or Today's date

    // Birth related: date and place
    public DateTime? BirthDate { get; set; }
    public DateTime? BirthDateRange { get; set; } //Used only if <see cref="BirthDateType" /> is set to "Between" and we need a date range
    public DateType? BirthDateType { get; set; }
    public Location? BirthPlace { get; set; }

    //Death related: date and place
    public DateTime? DeathDate { get; set; }
    public DateTime? DeathDateRange { get; set; } //Used only if <see cref="DeathDateType" /> is set to "Between" and we need a date range
    public DateType? DeathDateType { get; set; }
    public Location? DeathPlace { get; set; }
    public string? DeathCause { get; set; }
    public Location? BurialPlace { get; set; }

    // Other info (currently used for religion only)
    public string? Religion { get; set; }
    public Location? BaptismPlace { get; set; }
    public DateTime? BaptismDate { get; set; }
    public DateTime? BaptismRange { get; set; } //Used only if <see cref="BaptismDateType" /> is set to "Between" and we need a date range
    public DateType? BaptismDateType { get; set; }

    // Education: we use collection here as one person can have multiple educations
    public ObservableCollection<Education>? Educations { get; set; }

    // Work: we use collection here as one person can have multiple work places
    public ObservableCollection<Work>? Works { get; set; }

    public Bitmap? ProfileImg { get; set; }

    public static int? GetAge(bool isdeceased, DateTime? birthdate, DateTime? deathdate) {
        if (birthdate == null) {
            return null;
        } else if (isdeceased == false) {
            return DateTime.Now.AddTicks(0 - birthdate.GetValueOrDefault(DateTime.Now).Ticks).Year - 1; ;
        } else if (isdeceased == true && deathdate == null) {
            return null;
        } else {
            return deathdate.GetValueOrDefault(DateTime.Now).AddTicks(0 - birthdate.GetValueOrDefault(DateTime.Now).Ticks).Year - 1;
        }
    }

    public override string ToString() => FullName;

    public string FullName => $"{FirstName} {LastName}";


    public static ObservableCollection<Person>? PeopleList => new() {
        new Person() {
            Id = 1,
            Gender = "Male",
            FirstName = "Nikita",
            LastName = "Lebedin",
            IsDeceased = false,
            BirthDate = new DateTime(1998,03,03),

        },
        new Person() {
            Id = 2,
            Gender = "Male",
            FirstName = "Vasiliy",
            LastName = "Petrov",
            IsDeceased = true,
            BirthDate = new DateTime(1898,01,01),
            DeathDate = new DateTime(1975,01,07),
        },
        new Person() {
            Id = 3,
            Gender = "Female",
            FirstName = "Anna",
            LastName = "Aristova",
            IsDeceased = true,
            BirthDate = new DateTime(1888,12,12),

        },
        new Person() {
            Id = 4,
            Gender = "Male",
            FirstName = "Ivan",
            LastName = "Vanov",
            IsDeceased = false,
            BirthDate = new DateTime(1765,05,23),
        },
        new Person() {
            Id = 5,
            Gender = "Female",
            FirstName = "Fiona",
            LastName = "Shrekova",
            IsDeceased = true,
            BirthDate = new DateTime(1856,02,13),
        },
    };
}
