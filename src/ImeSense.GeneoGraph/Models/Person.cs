using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Models {
    public class Person    
    {
        public int Id { get; set; }

        public string? Sex { get; set; }

        public string? FirstName { get; set; } = "Unknown";
        public string? LastName { get; set; }

        public string? Patronim { get; set; }

        public string? MaidenName { get; set; }

        public bool IsAlive { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateOnly DeathDate { get; set; }

        public int Age { get; set; } /// Should be calculated based on Birth\Death date

    }
}
