using System;
using System.Threading.Tasks;
using System.Windows.Input;

using ImeSense.GeneoGraph.Helpers;
using ImeSense.GeneoGraph.Managers;
using ImeSense.GeneoGraph.Services;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels;

public class ProjectsViewModel : ReactiveObject
{
    private readonly ILogger<ProjectsViewModel> _logger;
    private readonly IFilesService _filesService;
    private readonly IProjectManager _projectManager;

    public ICommand CreateProjectCommand { get; }

    public ICommand OpenProjectCommand { get; }

    private async Task CreateProjectAsync()
    {
        var file = await _filesService.SaveFileAsync();
        if (file is null)
        {
            return;
        }

        await _projectManager.CreateProjectAsync(file);
    }

    private async Task OpenProjectAsync()
    {
        var file = await _filesService.OpenFileAsync();
        if (file is null)
        {
            return;
        }

        _projectManager.Project = await _projectManager.ReadProjectAsync(file);
    }

    public ProjectsViewModel(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetRequiredService<ILogger<ProjectsViewModel>>();
        _logger.BeginScope(nameof(ProjectsViewModel));

        _filesService = serviceProvider.GetRequiredService<IFilesService>();
        _projectManager = serviceProvider.GetRequiredService<IProjectManager>();

        CreateProjectCommand = ReactiveCommand.CreateFromTask(CreateProjectAsync);
        OpenProjectCommand = ReactiveCommand.CreateFromTask(OpenProjectAsync);
    }

    public ProjectsViewModel()
    {
        ExceptionHelper.EnsureNotInDesignTime(nameof(ProjectsViewModel));

        _logger = null!;
        _filesService = null!;
        _projectManager = null!;

        CreateProjectCommand = null!;
        OpenProjectCommand = null!;
    }
}
