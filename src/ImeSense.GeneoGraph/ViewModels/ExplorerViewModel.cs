using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.ViewModels {
    public class ExplorerViewModel : ObservableObject 
    {
        private ObservableCollection<string> _files;

        public ObservableCollection<string> Files {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        public ExplorerViewModel() 
        {
            Files = FileExplorer.GetFiles;
        }

    }
}
