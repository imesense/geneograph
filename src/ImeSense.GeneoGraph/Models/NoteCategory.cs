using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Models {
    public class NoteCategory
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public override string ToString() 
        { 
            return CategoryName; 
        
        }

        [Reactive]
        public static ObservableCollection<NoteCategory> CategoryList { get; set; } = new() 
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

    }
}
