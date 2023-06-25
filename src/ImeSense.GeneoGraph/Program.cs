using System;

using Avalonia;

namespace ImeSense.GeneoGraph;

internal class Program {
    /// <summary>
    /// Avalonia configuration, also used by visual designer
    /// </summary>
    /// <returns></returns>
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();

    /// <summary>
    /// Initialization code
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
}
