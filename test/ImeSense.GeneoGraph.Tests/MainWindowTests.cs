using Avalonia.Headless.NUnit;

using ImeSense.GeneoGraph.Services;
using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.Logging;

using Moq;

namespace ImeSense.GeneoGraph.Tests;

public class MainWindowTests {
    private Mock<ILogger<ProjectsViewModel>> _projectsLogger;
    private Mock<ILogger<MainViewModel>> _mainLogger;
    private Mock<IFilesService> _filesService;
    private ProjectsViewModel _projectsViewModel;
    private MainViewModel _mainViewModel;

    [SetUp]
    public void Initialize() {
        _projectsLogger = new Mock<ILogger<ProjectsViewModel>>();
        _mainLogger = new Mock<ILogger<MainViewModel>>();
        _filesService = new Mock<IFilesService>();
        _projectsViewModel = new ProjectsViewModel(_projectsLogger.Object, _filesService.Object);
        _mainViewModel = new MainViewModel(_mainLogger.Object, _projectsViewModel);
    }

    [AvaloniaTest]
    public void MainWindow_Show_ShouldBeVisible() {
        var window = new MainWindow {
            DataContext = _mainViewModel,
        };
        window.Show();

        Assert.Multiple(() => {
            Assert.That(window, Is.Not.Null);
            Assert.That(window.DataContext, Is.Not.Null);
            Assert.That(window.IsVisible, Is.True);
        });
    }
}
