using System;

using Avalonia.Controls;

namespace ImeSense.GeneoGraph.Helpers;

internal static class ExceptionHelper
{
    public static void EnsureNotInDesignTime(string className)
    {
        if (!Design.IsDesignMode)
        {
            throw new InvalidOperationException(
                $"Calling parameterless constructor of {className} class not in design-time!"
            );
        }
    }
}
