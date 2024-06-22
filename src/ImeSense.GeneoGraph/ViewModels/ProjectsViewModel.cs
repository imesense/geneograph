using System;
using System.Threading.Tasks;
using System.Windows.Input;

using ImeSense.GeneoGraph.Helpers;
using ImeSense.GeneoGraph.Services;

using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels;

public class ProjectsViewModel : ReactiveObject {
    private readonly ILogger<ProjectsViewModel> _logger;
    private readonly IFilesService _filesService;

    public ICommand CreateProjectCommand { get; }

    public ICommand OpenProjectCommand { get; }

    private async Task CreateProjectAsync() {
        try {
            var file = await _filesService.SaveFileAsync();
            if (file is null) {
                return;
            }
        } catch (Exception) {
        }
    }

    private async Task OpenProjectAsync() {
        try {
            var file = await _filesService.OpenFileAsync();
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
        OpenProjectCommand = ReactiveCommand.CreateFromTask(OpenProjectAsync);
    }

    public ProjectsViewModel() {
        ExceptionHelper.EnsureNotInDesignTime(nameof(ProjectsViewModel));

        _logger = null!;
        _filesService = null!;

        CreateProjectCommand = null!;
        OpenProjectCommand = null!;
    }
}
