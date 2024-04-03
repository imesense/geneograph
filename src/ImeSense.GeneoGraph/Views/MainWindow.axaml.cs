using ImeSense.GeneoGraph.ViewModels;
using Avalonia.ReactiveUI;

namespace ImeSense.GeneoGraph.Views {
    /// <summary>
    /// Interaction logic for MainWindow.axaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel> {
        public MainWindow() {
            InitializeComponent();
        }
    }
}
