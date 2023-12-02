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

        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> NotesList { get; set; } = new();

        [Reactive]
        public List<Note> FilteredNotes { get; set; } = new();

        [Reactive]
        public NoteCategory SelectedCategory { get; set; } = new();

        [Reactive]
        public Note SelectedNote { get; set; } = new();

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
