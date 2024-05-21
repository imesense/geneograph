using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapsui;

using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.ViewModels {
    public class MapViewModel : ReactiveObject 
    {
        public Map BoundMap { get; set; } = new Map();

    }
}
