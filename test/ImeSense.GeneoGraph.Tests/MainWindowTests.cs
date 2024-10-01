using Avalonia.Headless.NUnit;

using ImeSense.GeneoGraph.Extensions;
using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ImeSense.GeneoGraph.Tests;

public class MainWindowTests {
    private ProjectsViewModel _projectsViewModel;
    private MainViewModel _mainViewModel;

    [SetUp]
    public void Initialize() {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<MainWindow>()
            .AddViews()
            .AddViewModels()
            .AddServices()
            .AddLogging()
            .BuildServiceProvider();

        _projectsViewModel = new ProjectsViewModel(serviceProvider);
        _mainViewModel = new MainViewModel(serviceProvider);
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
