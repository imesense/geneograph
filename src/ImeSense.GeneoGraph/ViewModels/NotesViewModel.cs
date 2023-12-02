using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.ViewModels {
    public class NotesViewModel : ReactiveObject 
    {
        public NotesViewModel() 
        {
            CategoryList = new()
            {
                new NoteCategory {
                Id = 1,
                CategoryName = "All notes"},
                new NoteCategory {
                Id = 2,
                CategoryName = "Recent"},
                new NoteCategory {
                Id = 3,
                CategoryName = "Custom"},
            };

            NotesList = new() 
            {
                new Note 
                {
                NoteId = 1,
                NoteHeader = "Test Note",
                NoteDescription= "Test Lorem Ipsum",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= CategoryList[0],
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 2",
                NoteDescription= "Test Lorem Ipsum 2",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= CategoryList[1],
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 3",
                NoteDescription= "Test Lorem Ipsum 3",
                NoteText= "Test Lorem Ipsum This is an example of some long text although it might not be very long actually, but I try to make it look as long as I can",
                Category= CategoryList[2],
                AddedTime= DateTime.Now
                },
            };

            SelectedCategory = CategoryList[0];

            AddNoteCommand = ReactiveCommand.Create(AddNote);
        }


        private NoteCategory _selectedCategory;

        private Note _selectedNote;

        private List<Note> _filteredNotes;

        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> NotesList { get; set; } = new();

        [Reactive]
        public List<Note> FilteredNotes 
        {
            get => _filteredNotes;
            set => this.RaiseAndSetIfChanged(ref _filteredNotes, value);
        }

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

        public IReactiveCommand<Unit, Unit> AddNoteCommand { get; set; }

        public void AddNote() 
        {
            NotesList.Add(new Note() 
            {
                NoteId = NotesList.Last().NoteId + 1,
                NoteHeader = "New note",
                Category = SelectedCategory,
                AddedTime= DateTime.Now
        });
            SelectedNote = NotesList.Last();
            UpdateNotes();
        }

        private void UpdateNotes() {
            FilteredNotes = NotesList.Where(note => note.Category == _selectedCategory).ToList();

        }


    }
}
