using System;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using ImeSense.GeneoGraph.Extensions;
using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ImeSense.GeneoGraph;

public partial class App : Application
{
    private IServiceProvider _serviceProvider = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _serviceProvider = new ServiceCollection()
                .AddSingleton<MainWindow>()
                .AddViews()
                .AddViewModels()
                .AddServices()
                .AddManagers()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = mainViewModel;

            desktop.MainWindow = mainWindow;

            StorageLocator.StorageProvider = mainWindow.StorageProvider;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            _serviceProvider = new ServiceCollection()
                .AddViews()
                .AddViewModels()
                .AddServices()
                .AddManagers()
                .AddLogging()
                .BuildServiceProvider();

            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            var mainView = _serviceProvider.GetRequiredService<MainView>();
            mainView.DataContext = mainViewModel;

            singleViewPlatform.MainView = mainView;

            StorageLocator.StorageProvider = TopLevel.GetTopLevel(mainView)!.StorageProvider;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
