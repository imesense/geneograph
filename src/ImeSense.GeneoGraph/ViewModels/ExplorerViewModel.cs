using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Avalonia.Controls.Shapes;

using CommunityToolkit.Mvvm.ComponentModel;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.ViewModels {
    public class ExplorerViewModel : ObservableObject 
    {
        private ObservableCollection<string> _filesList;

        public ObservableCollection<string> FilesList {
            get => _filesList;
            set => SetProperty(ref _filesList, value);
        }

        private string dirPath = @"E:\Programming\VStudio\geneograph\projects\project_1";

        public ExplorerViewModel() 
        {

            FilesList = new ObservableCollection<string>();

            if(Directory.Exists(dirPath))
            {
                var getDirs = FileExplorer.ListDirectory(dirPath);
                var getFiles = FileExplorer.ListFiles(dirPath);

                foreach (var dir in getDirs) {
                    FilesList.Add(dir);
                }

                foreach (var file in getFiles) {
                    FilesList.Add(file);
                }
            }
        }

    }
}
