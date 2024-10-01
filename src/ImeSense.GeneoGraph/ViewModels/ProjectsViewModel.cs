using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

using ImeSense.GeneoGraph.Helpers;
using ImeSense.GeneoGraph.Models;
using ImeSense.GeneoGraph.Services;

using Microsoft.Extensions.DependencyInjection;
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

            var project = new Project {
                Name = file.Name,
            };
            var json = JsonSerializer.Serialize(project);
            var stream = new MemoryStream(Encoding.Default.GetBytes(json));
            await using var writeStream = await file.OpenWriteAsync();
            await stream.CopyToAsync(writeStream);
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

    public ProjectsViewModel(IServiceProvider serviceProvider) {
        _logger = serviceProvider.GetRequiredService<ILogger<ProjectsViewModel>>();
        _logger.BeginScope(nameof(ProjectsViewModel));

        _filesService = serviceProvider.GetRequiredService<IFilesService>();

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
