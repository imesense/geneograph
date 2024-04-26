using System;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace ImeSense.GeneoGraph.Themes;

public class GeneographTheme : Styles {
    /// <summary>
    /// Initializes new instance of <see cref="GeneographTheme"/> class
    /// for design-time preview
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public GeneographTheme() {
    }

    /// <summary>
    /// Initializes new instance of <see cref="GeneographTheme"/> class
    /// </summary>
    /// <param name="serviceProvider">Parent's service provider</param>
    public GeneographTheme(IServiceProvider? serviceProvider = null) {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
