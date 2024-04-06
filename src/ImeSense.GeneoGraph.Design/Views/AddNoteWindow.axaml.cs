using Avalonia.ReactiveUI;

using ImeSense.GeneoGraph.Design.ViewModels;

namespace ImeSense.GeneoGraph.Design.Views;

public partial class AddNoteWindow : ReactiveWindow<AddNoteViewModel> {
    public AddNoteWindow() => InitializeComponent();
}
