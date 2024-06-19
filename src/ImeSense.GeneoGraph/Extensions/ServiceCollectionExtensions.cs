using ImeSense.GeneoGraph.Services;
using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ImeSense.GeneoGraph.Extensions;

internal static class ServiceCollectionExtensions {
    public static IServiceCollection AddViews(this IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<MainView>();

        serviceCollection.AddSingleton<ProjectsView>();

        return serviceCollection;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection serviceCollection) {
        serviceCollection.AddSingleton<MainViewModel>();

        serviceCollection.AddSingleton<ProjectsViewModel>();

        return serviceCollection;
    }

    public static IServiceCollection AddServices(this IServiceCollection serviceCollection) {
        serviceCollection.AddTransient<IFilesService, FilesService>();

        return serviceCollection;
    }
}
