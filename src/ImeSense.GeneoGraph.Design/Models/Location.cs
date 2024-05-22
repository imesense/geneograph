using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Design.Models {
    public class Location 
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; } = string.Empty;

        public double LocationLatitude { get; set; } //For now this is a placeholder, we might not need it
        public double LocationLongitude { get; set; } //For now this is a placeholder, we might not need it

        public override string ToString() {
            return LocationName;
        }
    }
}
