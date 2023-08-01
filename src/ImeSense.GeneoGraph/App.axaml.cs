using System;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Microsoft.Extensions.DependencyInjection;

using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

namespace ImeSense.GeneoGraph;

public partial class App : Application {
    private readonly IServiceProvider _serviceProvider = null!;

    public App() {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<MainViewModel>()
            .AddSingleton<MainWindow>()
            .BuildServiceProvider();
    }

    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            desktop.MainWindow = _serviceProvider
                .GetRequiredService<MainWindow>();
            desktop.MainWindow.DataContext = _serviceProvider
                .GetRequiredService<MainViewModel>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
