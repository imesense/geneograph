using System;

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using ReactiveUI;

namespace ImeSense.GeneoGraph.Design {
    public class ViewLocator : IDataTemplate {
        public Control Build(object? data) {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var name = data.GetType().FullName?.Replace("ViewModel", "View");
            if (name == null)
                return new TextBlock { Text = "Invalid ViewModel type" };

            var type = Type.GetType(name);
            if (type != null) {
                try {
                    return (Control) Activator.CreateInstance(type)!;
                } catch (Exception ex) {
                    return new TextBlock { Text = $"Error creating view for {name}: {ex.Message}" };
                }
            }

            return new TextBlock { Text = $"View not found for {name}" };
        }

        public bool Match(object? data) {
            // Ensure that Match only matches ViewModels, not plain models like Photo
            return data is ReactiveObject;
        }
    }
}
