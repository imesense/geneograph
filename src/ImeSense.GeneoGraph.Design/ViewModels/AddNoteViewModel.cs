using System;
using System.Collections.ObjectModel;
using System.Reactive;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels {
    public class AddNoteViewModel : ReactiveObject {

        private readonly NotesViewModel _notesViewModel;

        [Reactive]
        public string NewNoteHeader { get; set; }

        [Reactive]
        public string NewNoteText { get; set; }

        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; }

        [Reactive]
        public NoteCategory SelectedCategory { get; set; }

        public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        // Parameterless constructor
        public AddNoteViewModel() {
            // Initialize commands
            AddNoteCommand = ReactiveCommand.Create(AddNote);
            CancelCommand = ReactiveCommand.Create(() => { });

            CategoryList = NoteCategory.CategoryList;
            SelectedCategory = CategoryList[0];
        }

        private void AddNote() {
            var newNote = new Note {
                NoteHeader = NewNoteHeader,
                NoteText = NewNoteText,
                Category = SelectedCategory,
                AddedTime = DateTime.Now
            };

            // Add the new note to the collection
            _notesViewModel.NotesList.Add(newNote);
        }
    }
}
