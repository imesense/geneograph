using CommunityToolkit.Mvvm.Input;

using Dock.Model.Mvvm.Controls;

using ImeSense.GeneoGraph.ViewModels.Documents;

namespace ImeSense.GeneoGraph.ViewModels.Docks;

public class FileDocumentDock : DocumentDock {
    private void CreateNewDocument() {
        if (!CanCreateDocument) {
            return;
        }

        var document = new FileViewModel();
        Factory?.AddDockable(this, document);
        Factory?.SetActiveDockable(document);
        Factory?.SetFocusedDockable(this, document);
    }

    public FileDocumentDock() {
        CreateDocument = new RelayCommand(CreateNewDocument);
    }
}
