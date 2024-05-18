using Avalonia.Headless.NUnit;

using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.ViewModels.Docks;
using ImeSense.GeneoGraph.ViewModels.Documents;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph.Tests;

public class MainWindowTests {
    private ProjectsViewModel _projectsViewModel;
    private ApplicationTabsDock _applicationTabsDock;
    private AppFactory _appFactory;
    private MainViewModel _mainViewModel;

    [SetUp]
    public void Initialize() {
        _projectsViewModel = new ProjectsViewModel();
        _applicationTabsDock = new ApplicationTabsDock(_projectsViewModel);
        _appFactory = new AppFactory(_projectsViewModel, _applicationTabsDock);
        _mainViewModel = new MainViewModel(_appFactory);
    }

    [TearDown]
    public void Deinitialization() {
        _mainViewModel.CloseLayout();
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

    [AvaloniaTest]
    public void MainWindow_CloseLayout_ShouldBeClosed() {
        var window = new MainWindow {
            DataContext = _mainViewModel,
        };
        window.Show();

        ((MainViewModel) window.DataContext).CloseLayout();

        Assert.That(((MainViewModel) window.DataContext).Layout, Is.Null);
    }
}
