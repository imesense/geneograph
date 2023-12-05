using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Security.Cryptography.X509Certificates;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Views;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels {
    public class NotesViewModel : ReactiveObject 
    {

        public static Window? _addNoteWindow;
        public static Window? _addCategoryWindow;
        public NotesViewModel() 
        {
            CategoryList = NoteCategory.CategoryList;

            NotesList = Note.NotesList;

            SelectedCategory = CategoryList[0];

            AddNoteOpenCommand = ReactiveCommand.Create(AddNoteOpen);
            AddCategoryOpenCommand = ReactiveCommand.Create(AddCategoryOpen);

        }

        private NoteCategory _selectedCategory;
        private Note _selectedNote;

        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> NotesList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> FilteredNotes { get; set; } = new();


        public NoteCategory SelectedCategory 
        {
            get => _selectedCategory;
            set {
                this.RaiseAndSetIfChanged(ref _selectedCategory, value);
                UpdateNotes();
            }
        }

        [Reactive]
        public Note SelectedNote 
        {
            get => _selectedNote;
            set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
        }

        public static void AddNoteOpen() {
            _addNoteWindow = new AddNoteWindow();
            _addNoteWindow.Show();
        }


        private void UpdateNotes() {
            var filterupdate = NotesList.Where(note => note.Category == _selectedCategory);
            FilteredNotes = new ObservableCollection<Note>(filterupdate);
        }

        public static void AddCategoryOpen() {
            _addCategoryWindow = new AddCategoryWindow();
            _addCategoryWindow.Show();
        }


        public IReactiveCommand<Unit, Unit> AddNoteOpenCommand { get; set; }
        public IReactiveCommand<Unit, Unit> AddCategoryOpenCommand { get; set; }



    }
}
