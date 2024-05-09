using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.ViewModels.Documents;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels.Docks;

public class ApplicationTabsDock : DocumentDock {
    private void CreateNewDocument() {
        if (!CanCreateDocument) {
            return;
        }

        var document = new ProjectsViewModel {
            Title = "",
        };
        Factory?.AddDockable(this, document);
        Factory?.SetActiveDockable(document);
        Factory?.SetFocusedDockable(this, document);
    }

    public ApplicationTabsDock() {
        CreateDocument = ReactiveCommand.Create(CreateNewDocument);
    }
}
