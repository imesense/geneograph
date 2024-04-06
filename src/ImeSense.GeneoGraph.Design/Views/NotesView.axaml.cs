using Avalonia.Controls;
using ImeSense.GeneoGraph.Design.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Threading.Tasks;
using Avalonia.LogicalTree;
using System.Linq;
using System;
using System.Runtime.InteropServices;

namespace ImeSense.GeneoGraph.Design.Views {
    public partial class NotesView : ReactiveUserControl<NotesViewModel> {
        public NotesView() {
            InitializeComponent();

            this.WhenActivated(disposables =>
                disposables(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));

            ///this.WhenActivated(d => d(ViewModel!.AddNewNoteCommand.Subscribe(Close)));
        }

        private async Task DoShowDialogAsync(IInteractionContext<NotesViewModel, AddNoteViewModel?> interaction) {
            var dialog = new AddNoteWindow();
            dialog.DataContext = interaction.Input;

            // Get the parent window from the UserControl's logical tree
            var mainWindow = this.GetLogicalAncestors().OfType<Window>().FirstOrDefault();

            if (mainWindow != null) 
            {
                var result = await dialog.ShowDialog<AddNoteViewModel?>(mainWindow);
                interaction.SetOutput(result);

            } 
            else 
            {
                // Handle the case where the parent window is not found
                // For example, if the UserControl is not hosted within a Window
                // You can provide an alternative behavior here
            }
        }
    }
}
