using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph.ViewModels {
    public class PeopleViewModel : ObservableObject
    {
        private Person _selectedPerson;
        private ObservableCollection<Person> _people;

        public List<string> PeopleSex { get; set; } = new List<string>() {"Male", "Female", "Unknown"};

        public PeopleViewModel() 
        {
            People = Person.GetPeople();

        }

        public Person SelectedPerson 
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public ObservableCollection<Person> People {
            get => _people;
            set => SetProperty(ref _people, value);
        }


        public void AddPersonOpen() 
        {
            NewPersonViewModel.AddPersonOpen();
        }

    }
}
