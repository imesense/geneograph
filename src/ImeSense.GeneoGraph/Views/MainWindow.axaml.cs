using Avalonia.Controls;
using ImeSense.GeneoGraph.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Views;

/// <summary>
/// Interaction logic for MainWindow.axaml
/// </summary>
public partial class MainWindow : ReactiveWindow<MainViewModel> {
    public MainWindow() 
    {
        InitializeComponent();

        this.WhenActivated(action =>
                action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<AddNoteViewModel,AddNoteReturnViewModel?> interaction) 
    {
        var dialog = new AddNoteWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<AddNoteReturnViewModel?>(this);
        interaction.SetOutput(result);
    }
}
