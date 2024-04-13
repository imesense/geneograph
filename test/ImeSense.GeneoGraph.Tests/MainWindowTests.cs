using Avalonia.Headless.NUnit;

using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph.Tests;

public class MainWindowTests {
    [AvaloniaTest]
    public void MainWindow_Show_ShouldBeViewed() {
        var window = new MainWindow {
            DataContext = new MainViewModel(),
        };
        window.Show();

        Assert.That(window.DataContext, Is.Not.Null);
        Assert.That(window.IsVisible, Is.True);
    }
}
