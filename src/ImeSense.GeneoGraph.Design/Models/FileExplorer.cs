using System.Collections.ObjectModel;

namespace ImeSense.GeneoGraph.Design.Models;

public class FileExplorer {
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
