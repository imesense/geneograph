using System;

using ImeSense.GeneoGraph.Helpers;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ReactiveObject
{
    private readonly ILogger _logger;
    private readonly ProjectsViewModel _projectsViewModel;

    private ReactiveObject? _projectsTabContent;

    public ReactiveObject? ProjectsTabContent
    {
        get => _projectsTabContent;
        set => this.RaiseAndSetIfChanged(ref _projectsTabContent, value);
    }

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetRequiredService<ILogger<MainViewModel>>();
        _projectsViewModel = serviceProvider.GetRequiredService<ProjectsViewModel>();

        ProjectsTabContent = _projectsViewModel;
    }

    public MainViewModel()
    {
        ExceptionHelper.EnsureNotInDesignTime(nameof(MainViewModel));

        _logger = null!;
        _projectsViewModel = null!;
    }
}
