using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.Helpers;
using ImeSense.GeneoGraph.ViewModels.Documents;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels.Docks;

public class ApplicationTabsDock : DocumentDock {
    private readonly ProjectsViewModel _projectsViewModel;

    private void CreateNewDocument() {
        if (!CanCreateDocument) {
            return;
        }

        var document = _projectsViewModel;
        document.Title = string.Empty;

        Factory?.AddDockable(this, document);
        Factory?.SetActiveDockable(document);
        Factory?.SetFocusedDockable(this, document);
    }

    public ApplicationTabsDock(ProjectsViewModel projectsViewModel) {
        _projectsViewModel = projectsViewModel;

        CreateDocument = ReactiveCommand.Create(CreateNewDocument);
    }

    public ApplicationTabsDock() {
        ExceptionHelper.EnsureNotInDesignTime(nameof(ApplicationTabsDock));

        _projectsViewModel = null!;

        CreateDocument = null!;
    }
}
