using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels {
    public class FamilyTreeViewModel : ReactiveObject {

        private Person? _selectedPerson;
        private bool _sidebarStatus = false;

        private ObservableCollection<Person>? _peopleList;

        private int _selectedIndex;

        private static Window? _addPersonWindow;

        public FamilyTreeViewModel() {
            PeopleGender = new() {
            "Male", "Female", "Unknown",
            };

            PeopleList = Person.GetPeople();

            SideBarOpenCloseCommand = ReactiveCommand.Create(SideBarOpenClose);
        }

        public List<string> PeopleGender { get; set; }

        public bool SidebarStatus {
            get => _sidebarStatus;
            set => this.RaiseAndSetIfChanged(ref _sidebarStatus, value);
        }

        public ObservableCollection<Person>? PeopleList {
            get => _peopleList;
            set => this.RaiseAndSetIfChanged(ref _peopleList, value);
        }

        public Person? SelectedPerson {
            get => _selectedPerson;
            set => this.RaiseAndSetIfChanged(ref _selectedPerson, value);
        }

        public int SelectedIndex {
            get => _selectedIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedIndex, value);
        }

        public IReactiveCommand<Unit, Unit> AddPersonOpenCommand { get; set; } = ReactiveCommand.Create(AddPersonOpen);
        public IReactiveCommand<Unit, Unit> AddPersonCloseCommand { get; set; } = ReactiveCommand.Create(AddPersonClose);
        public IReactiveCommand<Unit, Unit> SideBarOpenCloseCommand { get; set; }

        public static void AddPersonOpen() {
            _addPersonWindow = new NewPerson();
            _addPersonWindow.Show();

        }

        public static void AddPersonClose() {
            _addPersonWindow?.Close();
        }

        public void SideBarOpenClose() 
        {
           if (SidebarStatus == false && SelectedPerson == null) 
            {
                SelectedPerson = PeopleList?.FirstOrDefault();
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
