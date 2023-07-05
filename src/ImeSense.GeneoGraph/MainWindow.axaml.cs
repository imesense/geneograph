using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ImeSense.GeneoGraph.Views;

/// <summary>
/// Interaction logic for MainWindow.axaml
/// </summary>
public partial class MainWindow : Window {
    private void InitializeComponent() =>
        AvaloniaXamlLoader.Load(this);

    public MainWindow() =>
        InitializeComponent();
}
