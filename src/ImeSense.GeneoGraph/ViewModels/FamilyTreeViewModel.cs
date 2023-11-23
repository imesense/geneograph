using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Collections;
using Avalonia.Controls;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph.ViewModels {
    public class FamilyTreeViewModel : ObservableObject {

        private Person? _selectedPerson;
        private bool _sidebarStatus = false;

        private ObservableCollection<Person>? _peopleList;

        private int _selectedIndex;

        private IRelayCommand? _addPersonOpenCommand;
        private IRelayCommand? _addPersonCloseCommand;
        private IRelayCommand? _sideBarOpenCloseCommand;

        private static Window? _addPersonWindow;

        public FamilyTreeViewModel() {
            PeopleGender = new() {
            "Male", "Female", "Unknown",
            };

            PeopleList = Person.GetPeople();

        }

        public List<string> PeopleGender { get; set; }

        public bool SidebarStatus {
            get => _sidebarStatus;
            set => SetProperty(ref _sidebarStatus, value);
        }

        public ObservableCollection<Person>? PeopleList {
            get => _peopleList;
            set => SetProperty(ref _peopleList, value);
        }

        public Person? SelectedPerson {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public int SelectedIndex {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public IRelayCommand AddPersonOpenCommand => _addPersonOpenCommand ??= new RelayCommand(AddPersonOpen);
        public IRelayCommand AddPersonCloseCommand => _addPersonCloseCommand ??= new RelayCommand(AddPersonClose);
        public IRelayCommand SideBarOpenCloseCommand => _sideBarOpenCloseCommand ??= new RelayCommand(SideBarOpenClose);

        public static void AddPersonOpen() {
            _addPersonWindow = new NewPerson();
            _addPersonWindow.Show();

        }

        public static void AddPersonClose() {
            _addPersonWindow.Close();
        }

        public void SideBarOpenClose() 
        {
           if (SidebarStatus == false && SelectedPerson == null) 
            {
                SelectedPerson = PeopleList.First();
                SidebarStatus = true;
            }
           else if (SidebarStatus == false)
            {
                SidebarStatus = true;
            }
           else 
           {
                SidebarStatus = false;
           }
        }
    }
}
