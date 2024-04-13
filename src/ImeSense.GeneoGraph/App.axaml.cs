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
            var mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow {
                DataContext = mainViewModel,
            };
            mainWindow.Closing += (_, _) => {
                mainViewModel.CloseLayout();
            };

            desktop.MainWindow = mainWindow;
            desktop.Exit += (_, _) => {
                mainViewModel.CloseLayout();
            };
        } else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform) {
            var mainViewModel = new MainViewModel();
            var mainView = new MainView {
                DataContext = mainViewModel,
            };
            mainView.Unloaded += (_, _) => {
                mainViewModel.CloseLayout();
            };

            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
