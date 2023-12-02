using System.Collections.ObjectModel;

using ImeSense.GeneoGraph.Models;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels {
    public class FilesViewModel : ReactiveObject {
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
