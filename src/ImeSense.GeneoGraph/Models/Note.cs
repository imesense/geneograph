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

        public string NoteHeader { get; set; }

        public string NoteText { get; set; }
        public string NoteDescription { get; set; }

        public NoteCategory Category { get; set; }

        public DateTime AddedTime { get; set; }

    }
}
