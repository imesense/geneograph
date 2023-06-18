using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Models {
    public class Person    
    {
        public int Id { get; set; }

        public string? FirstName { get; set; } = "Unknown";
        public string? LastName { get; set; }

        public string? Patronim { get; set; }

        public string? MaidenName { get; set; }

        public string? Sex { get; set; }

        public bool IsDeceased { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateOnly DeathDate { get; set; }

        public int Age { get; set; } /// Should be calculated based on Birth\Death date

        public override string ToString() {
            return FullName;
        }

        public string FullName => $"{Id}. {FirstName} {LastName}";


        public static ObservableCollection<Person> People = new() {
            new Person() { Id = 1,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 2,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 3,Sex = "Female",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 4,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 5,Sex = "Female",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 6,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 7,Sex = "Female",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 8,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 9,Sex = "Male",FirstName = "MaleName",LastName = "LastName", IsDeceased = true},
            new Person() { Id = 10,Sex = "Female",FirstName = "FemaleName",LastName = "LastName", IsDeceased = false}
        };


        public static ObservableCollection<Person> GetPeople() 
        {
            return People;
        }

        public static void AddPerson(string sex, string firstname, string lastname, bool isDeceased, DateOnly birthdate, DateOnly deathdate) {
            int newID = People.Last().Id + 1;
            People.Add(new Person() { Id = newID, Sex = sex, FirstName = firstname, LastName = lastname, IsDeceased = isDeceased, BirthDate = birthdate, DeathDate = deathdate });
        }

    }
}
