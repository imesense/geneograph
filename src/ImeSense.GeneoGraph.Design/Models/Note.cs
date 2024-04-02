using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImeSense.GeneoGraph.Design.ViewModels;

using ReactiveUI.Fody.Helpers;
using ImeSense.GeneoGraph.Design.Models;
using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.Models {
    public class Note {

        public int NoteId { get; set; }

        public string NoteHeader { get; set; } = string.Empty;

        public string NoteText { get; set; } = string.Empty;

        public NoteCategory Category { get; set; } = new();

        public DateTime AddedTime { get; set; }
        public DateTime? NoteDateProperty { get; set; }

        public string? NoteSource { get; set; }

        [Reactive]
        public static ObservableCollection<Note> NotesList { get; set; } = new() {
                new Note
                {
                NoteId = 1,
                NoteHeader = "Test Note",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= NoteCategory.CategoryList[0],
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 2",
                NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Category= NoteCategory.CategoryList[1],
                AddedTime= DateTime.Now
                },
                new Note
                {
                NoteId = 2,
                NoteHeader = "Test Note 3",
                NoteText= "Test Lorem Ipsum This is an example of some long text although it might not be very long actually, but I try to make it look as long as I can",
                Category= NoteCategory.CategoryList[2],
                AddedTime= DateTime.Now
                },
            };

    }
}
