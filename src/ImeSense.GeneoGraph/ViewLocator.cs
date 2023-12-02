using System;

using Avalonia.Controls.Templates;
using Avalonia.Controls;

using Dock.Model.Core;

using ReactiveUI;

namespace ImeSense.GeneoGraph;

public class ViewLocator : IDataTemplate {
    public Control Build(object? data) {
        var name = data!.GetType()
            .FullName!
            .Replace("ViewModel", "View");
        var type = Type.GetType(name);
        if (type != null) {
            return (Control) Activator.CreateInstance(type)!;
        }
        return new TextBlock {
            Text = name,
        };
    }

    public bool Match(object? data) {
        return
            data is ReactiveObject ||
            data is IDockable;
    }
}
