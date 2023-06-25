using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ImeSense.GeneoGraph.Views;

/// <summary>
/// Interaction logic for NewPerson.axaml
/// </summary>
public class NewPerson : Window {
    private void InitializeComponent() =>
        AvaloniaXamlLoader.Load(this);

    public NewPerson() =>
        InitializeComponent();
}
