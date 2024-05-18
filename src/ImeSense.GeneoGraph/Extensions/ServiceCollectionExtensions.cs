using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.ViewModels.Docks;
using ImeSense.GeneoGraph.ViewModels.Documents;
using ImeSense.GeneoGraph.Views;
using ImeSense.GeneoGraph.Views.Documents;

using Microsoft.Extensions.DependencyInjection;

namespace ImeSense.GeneoGraph.Extensions;

internal static class ServiceCollectionExtensions {
    public static IServiceCollection AddViews(this IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainView>();

        serviceCollection.AddSingleton<ProjectsView>();

        return serviceCollection;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<AppFactory>();
        serviceCollection.AddSingleton<ApplicationTabsDock>();

        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddSingleton<ProjectsViewModel>();

        return serviceCollection;
    }
}
