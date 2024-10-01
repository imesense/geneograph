using System;

using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace ImeSense.GeneoGraph.Themes;

public class GeneographTheme : Styles
{
    /// <summary>
    /// Initializes new instance of <see cref="GeneographTheme"/> class
    /// </summary>
    /// <param name="serviceProvider">Parent's service provider</param>
    public GeneographTheme(IServiceProvider? serviceProvider = null)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
