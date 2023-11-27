using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using System.Xml.Linq;

namespace ImeSense.GeneoGraph.Models {
    public class FileExplorer
    {
        public ObservableCollection<FileExplorer>? SubNodes { get; }
        public string Title { get; }

        public FileExplorer(string title) {
            Title = title;
        }

        public FileExplorer(string title, ObservableCollection<FileExplorer> subNodes) {
            Title = title;
            SubNodes = subNodes;
        }

    }
}
