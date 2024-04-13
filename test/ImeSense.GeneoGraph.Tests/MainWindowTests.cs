using Avalonia.Headless.NUnit;

using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph.Tests;

public class MainWindowTests {
    [AvaloniaTest]
    public void MainWindow_Show_ShouldBeVisible() {
        var window = new MainWindow {
            DataContext = new MainViewModel(),
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
            DataContext = new MainViewModel(),
        };
        window.Show();

        ((MainViewModel) window.DataContext).CloseLayout();

        Assert.That(((MainViewModel) window.DataContext).Layout, Is.Null);
    }
}
