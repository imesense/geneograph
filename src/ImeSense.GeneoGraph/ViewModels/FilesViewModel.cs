using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.ViewModels.Tools;
using ImeSense.GeneoGraph.Views;


namespace ImeSense.GeneoGraph.ViewModels {
    public class FilesViewModel : ObservableObject 
    {
        public ObservableCollection<FileExplorer> Nodes { get; }

        public FilesViewModel() {
            Nodes = new ObservableCollection<FileExplorer>
            {
                new FileExplorer("Test", new ObservableCollection<FileExplorer>
                {
                    new FileExplorer("Test1", new ObservableCollection<FileExplorer>
                    {
                        new FileExplorer("Test2"), new FileExplorer("Test3"), new FileExplorer("Test4")
                    })
                })
            };
        }

    }
}
