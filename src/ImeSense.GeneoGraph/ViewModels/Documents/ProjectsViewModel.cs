using System;
using System.Threading.Tasks;
using System.Windows.Input;

using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.Helpers;
using ImeSense.GeneoGraph.Services;

using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels.Documents;

public class ProjectsViewModel : Document {
    private readonly ILogger<ProjectsViewModel> _logger;
    private readonly IFilesService _filesService;

    public ICommand CreateProjectCommand { get; }

    private async Task CreateProjectAsync() {
        try {
            var filesService = _filesService;

            var file = await filesService.SaveFileAsync();
            if (file is null) {
                return;
            }
        } catch (Exception) {
        }
    }

    public ProjectsViewModel(ILogger<ProjectsViewModel> logger,
        IFilesService filesService) {
        _logger = logger;
        _logger.BeginScope(nameof(ProjectsViewModel));

        _filesService = filesService;

        CreateProjectCommand = ReactiveCommand.CreateFromTask(CreateProjectAsync);
    }

    public ProjectsViewModel() {
        ExceptionHelper.EnsureNotInDesignTime(nameof(ProjectsViewModel));

        _logger = null!;
        _filesService = null!;

        CreateProjectCommand = null!;
    }
}
