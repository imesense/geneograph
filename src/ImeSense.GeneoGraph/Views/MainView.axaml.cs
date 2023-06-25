using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ImeSense.GeneoGraph.Views;

/// <summary>
/// Interaction logic for MainView.axaml
/// </summary>
public class MainView : UserControl {
    private void InitializeComponent() =>
        AvaloniaXamlLoader.Load(this);

    public MainView() =>
        InitializeComponent();
}
