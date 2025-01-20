using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Layout.Models {
    public class Location 
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; } = string.Empty;

        public double? LocationLatitude { get; set; } //For now this is a placeholder, we might not need it
        public double? LocationLongitude { get; set; } //For now this is a placeholder, we might not need it

        public override string ToString() {
            return LocationName;
        }

        public static ObservableCollection<Location> ListLocations { get; set; } = new() 
        { 
            new Location 
            {
                LocationId = 1,
                LocationName = "TestLocation1"
            },
            new Location 
            {
                LocationId = 2,
                LocationName = "TestLocation2"
            },
            new Location 
            {
                LocationId = 3,
                LocationName = "TestLocation3"
            },
        };
    }
}
