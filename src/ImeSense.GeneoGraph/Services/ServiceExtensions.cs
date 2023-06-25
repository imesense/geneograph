using ImeSense.GeneoGraph.ViewModels;
using ImeSense.GeneoGraph.Views;

using Microsoft.Extensions.DependencyInjection;

namespace ImeSense.GeneoGraph.Services;

public static class ServiceExtensions {
    public static IServiceCollection AddViews(this IServiceCollection services) {
        services.AddSingleton<MainWindow>();
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services) {
        services.AddSingleton<MainViewModel>();
        return services;
    }
}
