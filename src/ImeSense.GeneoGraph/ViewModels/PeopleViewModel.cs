using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.ViewModels {
    public class PeopleViewModel : ObservableObject
    {
        private Person _selectedPerson;

        public ObservableCollection<Person> PeopleList { get; set; }
        public List<string> PeopleSex { get; set; } = new List<string>() {"Male", "Female", "Unknown"};

        public PeopleViewModel() 
        {
            PeopleList = new ObservableCollection<Person>(Person.GetPeople());
        }

        public Person SelectedPerson 
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }


    }
}
