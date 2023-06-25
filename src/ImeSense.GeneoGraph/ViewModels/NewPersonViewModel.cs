using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

using Tmds.DBus;

namespace ImeSense.GeneoGraph.ViewModels {
    public class NewPersonViewModel : ObservableObject
    {

        private bool _gendermale;
        private bool _genderfemale;
        private string _selectedgender = "Unknown";
        private string? _firstname;
        private string? _lastname;
        private bool _isdeceased = false;
        private DateOnly _birthdate;
        private DateOnly _deathdate;

        private IRelayCommand? _addPersonCommand;

        private static Window _addPersonWindow;

        public bool GenderMale
        {
            get => _gendermale;
            set => SetProperty(ref _gendermale, value);

        }

        public bool GenderFemale 
        {
            get => _genderfemale;
            set => SetProperty(ref _genderfemale, value);

        }

        public string SelectedGender {
            get => _selectedgender;
            set => SetProperty(ref _selectedgender, value);

        }

        public string? FirstName 
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);

        }

        public string? LastName 
        {
            get => _lastname;
            set => SetProperty(ref _lastname, value);

        }

        public bool IsDeceased 
        {
            get => _isdeceased;
            set => SetProperty(ref _isdeceased, value);

        }

        public DateOnly BirthDate 
        {
            get => _birthdate;
            set => SetProperty(ref _birthdate, value);
        }

        public DateOnly DeathDate 
        {
            get => _deathdate;
            set => SetProperty(ref _deathdate, value);
        }

        private void GenderSelector() 
        {
            if (GenderMale == true) {
                SelectedGender = "Male";
            } else if (GenderFemale == true) {
                SelectedGender = "Female";
            } else {
                SelectedGender = "Unknown";
            }
        }

        private void AddPerson() 
        {
            GenderSelector();

            FirstName ??= "Unknown";

            Person.AddPerson(SelectedGender, FirstName, LastName, IsDeceased, BirthDate, DeathDate);

            _addPersonWindow.Close();
        }

        public IRelayCommand AddPersonCommand => _addPersonCommand ??= new RelayCommand(AddPerson);

        public static void AddPersonOpen() {

            _addPersonWindow = new NewPerson();
            _addPersonWindow.Show();

        }

        private static void AddPersonClose() 
        {
            _addPersonWindow.Close();
        }

    }
}
