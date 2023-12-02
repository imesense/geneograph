using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels {
    public class NotesViewModel : ReactiveObject 
    {
        private ObservableCollection<NoteCategory> _categoryList = new();
        private ObservableCollection<Note> _notesList = new();
        private List<Note> _filteredNotes = new();

        private NoteCategory _selectedCategory = new();
        private Note _selectedNote = new();

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
                Category= CategoryList[0],
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 3",
                NoteDescription= "Test Lorem Ipsum 3",
                NoteText= "Test Lorem Ipsum This is an example of some long text although it might not be very long actually, but I try to make it look as long as I can",
                Category= CategoryList[0],
                AddedTime= DateTime.Now
                },
            };

            SelectedCategory = CategoryList[0];

            FilteredNotes = NotesList.Where(note => note.Category == SelectedCategory).ToList();

            AddNoteCommand = ReactiveCommand.Create(AddNote);
        }

        public ObservableCollection<NoteCategory> CategoryList {
            get => _categoryList;
            set => this.RaiseAndSetIfChanged(ref _categoryList, value);
        }

        public ObservableCollection<Note> NotesList {
            get => _notesList;
            set => this.RaiseAndSetIfChanged(ref _notesList, value);
        }

        public List<Note> FilteredNotes {
            get => _filteredNotes;
            set => this.RaiseAndSetIfChanged(ref _filteredNotes, value);
        }

        public NoteCategory SelectedCategory {
            get => _selectedCategory;
            set => this.RaiseAndSetIfChanged(ref _selectedCategory, value);
        }

        public Note SelectedNote {
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
            SelectedNote= NotesList.Last();
        }



    }
}
