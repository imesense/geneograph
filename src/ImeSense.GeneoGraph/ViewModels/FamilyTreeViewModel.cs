using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels {
    public class FamilyTreeViewModel : ReactiveObject {
        private static Window? _addPersonWindow;

        private bool _sidebarStatus;
        private Person? _selectedPerson;

        public FamilyTreeViewModel() {
            PeopleGender = new() {
            "Male", "Female", "Unknown",
            };

            PeopleList = Person.GetPeople();

            SideBarOpenCloseCommand = ReactiveCommand.Create(SideBarOpenClose);
        }

        public List<string> PeopleGender { get; set; }

        [Reactive]
        public bool SidebarStatus 
        {
            get => _sidebarStatus;
            set => this.RaiseAndSetIfChanged(ref _sidebarStatus, value);
        }

        [Reactive]
        public ObservableCollection<Person>? PeopleList { get; set; }

        [Reactive]
        public Person? SelectedPerson 
        {
            get => _selectedPerson;
            set => this.RaiseAndSetIfChanged(ref _selectedPerson, value);
        }

        [Reactive]
        public int SelectedIndex { get; set; }

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