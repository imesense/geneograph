using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.Helpers;

using Microsoft.Extensions.Logging;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class ProjectsViewModel : Document {
    private readonly ILogger<ProjectsViewModel> _logger;

    public ProjectsViewModel(ILogger<ProjectsViewModel> logger) {
        _logger = logger;
        _logger.BeginScope(nameof(ProjectsViewModel));
    }

    public ProjectsViewModel() {
        ExceptionHelper.EnsureNotInDesignTime(nameof(ProjectsViewModel));

        _logger = null!;
    }
}
