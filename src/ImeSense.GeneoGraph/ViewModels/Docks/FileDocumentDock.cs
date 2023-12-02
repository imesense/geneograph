using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.ViewModels.Documents;

using ReactiveUI;

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
        CreateDocument = ReactiveCommand.Create(CreateNewDocument);
    }
}
