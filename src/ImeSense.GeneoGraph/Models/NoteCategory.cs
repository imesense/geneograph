using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Models {
    public class NoteCategory
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public override string ToString() 
        { 
            return CategoryName; 
        
        }

    }
}
