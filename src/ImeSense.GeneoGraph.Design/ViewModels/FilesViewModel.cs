using System.Collections.ObjectModel;

using ImeSense.GeneoGraph.Design.Models;

using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.ViewModels;

public class FilesViewModel : ReactiveObject {
    public ObservableCollection<FileExplorer> Nodes { get; }

    public FilesViewModel() {
        Nodes = new ObservableCollection<FileExplorer> {
            new("Test", new ObservableCollection<FileExplorer> {
                new("Test1", new ObservableCollection<FileExplorer> {
                    new("Test2"),
                    new("Test3"),
                    new("Test4"),
                })
            })
        };
    }
}
