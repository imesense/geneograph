using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImeSense.GeneoGraph.ViewModels;

namespace ImeSense.GeneoGraph.Models {
    public class Note {

        public int NoteId { get; set; }

        public string NoteHeader { get; set; } = string.Empty;

        public string NoteText { get; set; } = string.Empty;
        public string NoteDescription { get; set; } = string.Empty;

        public NoteCategory Category { get; set; } = new();

        public DateTime AddedTime { get; set; }

    }
}
