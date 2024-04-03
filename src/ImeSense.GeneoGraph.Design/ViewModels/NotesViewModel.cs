using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Avalonia.Controls;
using Avalonia.ReactiveUI;

using ImeSense.GeneoGraph.Design.Models;
using ImeSense.GeneoGraph.Design.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels {
    public class NotesViewModel : ReactiveObject
    {

        public static Window? _addNoteWindow;
        public static Window? _addCategoryWindow;

        public int _selectedNoteIndex;

        public Interaction<NotesViewModel, AddNoteViewModel?> ShowDialog { get; }
        public ICommand AddNoteOpenCommand { get; }

        public NotesViewModel() 
        {
            CategoryList = NoteCategory.CategoryList;

            NotesList = Note.NotesList;

            SelectedCategory = CategoryList[0];

            AddCategoryOpenCommand = ReactiveCommand.Create(AddCategoryOpen);
            DeleteNoteCommand = ReactiveCommand.Create(DeleteNote);
            IsFavNoteChangeCommand = ReactiveCommand.Create(IsFavStateChange);
            LoadFavNoteCommand = ReactiveCommand.Create(LoadFavoriteNotes);

            ShowDialog = new Interaction<NotesViewModel, AddNoteViewModel?>();

            AddNoteOpenCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new NotesViewModel();

                var result = await ShowDialog.Handle(store);
            });
        }

        private NoteCategory _selectedCategory;
        private Note _selectedNote;

        [Reactive]
        public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> NotesList { get; set; } = new();

        [Reactive]
        public ObservableCollection<Note> FilteredNotes { get; set; } = new();


        public NoteCategory SelectedCategory 
        {
            get => _selectedCategory;
            set {
                this.RaiseAndSetIfChanged(ref _selectedCategory, value);
                UpdateNotes();
            }
        }

        [Reactive]
        public Note SelectedNote 
        {
            get => _selectedNote;
            set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
        }

        public int SelectedNoteIndex {
            get => _selectedNoteIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedNoteIndex, value);
        }

        public static void AddCategoryOpen() {
            _addCategoryWindow = new AddCategoryWindow();
            _addCategoryWindow.Show();
        }

        private void UpdateNotes() {
            var filterupdate = NotesList.Where(note => note.Category == _selectedCategory);
            FilteredNotes = new ObservableCollection<Note>(filterupdate);
        }

        private void LoadFavoriteNotes() {
            var loadfavs = NotesList.Where(note => note.IsFavorite == true);
            FilteredNotes.Clear();
            FilteredNotes = new ObservableCollection<Note>(loadfavs);
        }


        public void DeleteNote() {
            NotesList.RemoveAt(SelectedNoteIndex);
        }
        public void IsFavStateChange() {
            if (SelectedNote.IsFavorite == false) {
                SelectedNote.IsFavorite = true;
            } 
            else 
            {
                SelectedNote.IsFavorite = false;
            }
        }

        public IReactiveCommand<Unit, Unit> AddCategoryOpenCommand { get; set; }

        public IReactiveCommand<Unit, Unit> DeleteNoteCommand { get; set; }
        public IReactiveCommand<Unit, Unit> IsFavNoteChangeCommand { get; set; }
        public IReactiveCommand<Unit, Unit> LoadFavNoteCommand { get; set; }



    }
}
