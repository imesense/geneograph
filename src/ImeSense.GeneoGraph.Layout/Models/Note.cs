using System;
using System.Collections.ObjectModel;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Layout.Models;

public class Note {
    public int NoteId { get; set; }
    public string NoteHeader { get; set; } = string.Empty;
    public string NoteText { get; set; } = string.Empty;

    public NoteCategory Category { get; set; } = new();
    public DateTime? NoteDate { get; set; }
    public Source? NoteSource { get; set; }
    public bool IsFavorite { get; set; } = false;

    public DateTime AddedTime { get; set; }

    [Reactive]
    public static ObservableCollection<Note> NotesList { get; set; } = new() {
        new Note {
            NoteId = 1,
            NoteHeader = "Test Note",
            NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
            Category= NoteCategory.CategoryList[0],
            NoteSource= Source.ListSources[0],
            NoteDate = DateTime.Now,
            AddedTime= DateTime.Now
        },
        new Note {
            NoteId = 2,
            NoteHeader = "Test Note 2",
            NoteText= "Test Lorem Ipsum AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA AAAAAAAAAAAAAAAAAAAAAAAAAAA",
            Category= NoteCategory.CategoryList[1],
            NoteSource= Source.ListSources[1],
            NoteDate = DateTime.Now,
            AddedTime= DateTime.Now
        },
        new Note {
            NoteId = 2,
            NoteHeader = "Test Note 3",
            NoteText= "Test Lorem Ipsum This is an example of some long text although it might not be very long actually, but I try to make it look as long as I can",
            Category= NoteCategory.CategoryList[2],
            NoteSource= Source.ListSources[2],
            NoteDate = DateTime.Now,
            AddedTime= DateTime.Now
        },
    };
}
