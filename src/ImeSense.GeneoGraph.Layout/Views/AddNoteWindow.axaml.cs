using Avalonia.ReactiveUI;

using ImeSense.GeneoGraph.Layout.ViewModels;

namespace ImeSense.GeneoGraph.Layout.Views;

public partial class AddNoteWindow : ReactiveWindow<AddNoteViewModel> {
    public AddNoteWindow() => InitializeComponent();
}
