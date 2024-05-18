using System;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using ImeSense.GeneoGraph.Extensions;
using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ImeSense.GeneoGraph;

public partial class App : Application {
    private readonly IServiceProvider _serviceProvider = null!;

    public App() {
        _serviceProvider = new ServiceCollection()
            .AddViews()
            .AddViewModels()
            .AddLogging(builder => builder.AddConsole())
            .BuildServiceProvider();
    }

    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted() {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = mainViewModel;
            mainWindow.Closing += (_, _) => {
                mainViewModel.CloseLayout();
            };

            desktop.MainWindow = mainWindow;
            desktop.Exit += (_, _) => {
                mainViewModel.CloseLayout();
            };
        } else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform) {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var mainView = _serviceProvider.GetRequiredService<MainView>();
            mainView.DataContext = mainViewModel;
            mainView.Unloaded += (_, _) => {
                mainViewModel.CloseLayout();
            };

            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
