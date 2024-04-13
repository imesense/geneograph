using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Design.Models;
using ImeSense.GeneoGraph.Design.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels;

public class NotesViewModel : ReactiveObject {
    private Window? _addCategoryWindow;

    public int _selectedNoteIndex;

    private bool _rightDockVisibility = false;
    private int _numberNotes = 0;

    public Interaction<NotesViewModel, AddNoteViewModel?> ShowDialog { get; }

    public ICommand AddNoteOpenCommand { get; }

    public ReactiveCommand<AddNoteViewModel?, Unit> AddNewNoteCommand { get; }

    public NotesViewModel() {
        _selectedCategory = new NoteCategory();
        _selectedNote = new Note();

        CategoryList = NoteCategory.CategoryList;

        NotesList = Note.NotesList;

        AddNewNoteCommand = ReactiveCommand.Create<AddNoteViewModel?, Unit>((_) => Unit.Default);

        AddCategoryOpenCommand = ReactiveCommand.Create(AddCategoryOpen);
        DeleteNoteCommand = ReactiveCommand.Create(DeleteNote);
        IsFavNoteChangeCommand = ReactiveCommand.Create(IsFavStateChange);
        LoadFavNoteCommand = ReactiveCommand.Create(LoadFavoriteNotes);
        LoadAllNotesCommand = ReactiveCommand.Create(LoadAllNotes);

        ShowDialog = new Interaction<NotesViewModel, AddNoteViewModel?>();

        AddNoteOpenCommand = ReactiveCommand.CreateFromTask(async () => {
            var store = new NotesViewModel();
            var result = await ShowDialog.Handle(store);
        });

        this.WhenAnyValue(x => x.SelectedNoteIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index >= 0)
            .Subscribe(_ => RightDockVisibility = true);

        this.WhenAnyValue(x => x.SelectedNoteIndex)
            .Skip(2) // Skip initial null value
            .Where(index => index < 0)
            .Subscribe(_ => RightDockVisibility = false);

        this.WhenAnyValue(x => x.SelectedCategory)
            .Subscribe(_ => DisplayCategory = SelectedCategory.CategoryName);

        LoadAllNotes();
    }

    private NoteCategory _selectedCategory;
    private Note _selectedNote;

    [Reactive]
    public ObservableCollection<NoteCategory> CategoryList { get; set; } = new();

    [Reactive]
    public ObservableCollection<Note> NotesList { get; set; } = new();

    [Reactive]
    public ObservableCollection<Note> FilteredNotes { get; set; } = new();

    public NoteCategory SelectedCategory {
        get => _selectedCategory;
        set {
            this.RaiseAndSetIfChanged(ref _selectedCategory, value);
            UpdateNotes();
        }
    }

    [Reactive]
    public string DisplayCategory { get; set; } = "All Notes";

    [Reactive]
    public Note SelectedNote {
        get => _selectedNote;
        set => this.RaiseAndSetIfChanged(ref _selectedNote, value);
    }

    public int SelectedNoteIndex {
        get => _selectedNoteIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedNoteIndex, value);
    }

    [Reactive]
    public int NumberNotes {
        get => _numberNotes;
        set => this.RaiseAndSetIfChanged(ref _numberNotes, value);
    }

    [Reactive]
    public bool RightDockVisibility {
        get => _rightDockVisibility;
        set => this.RaiseAndSetIfChanged(ref _rightDockVisibility, value);
    }

    public void AddCategoryOpen() {
        _addCategoryWindow = new AddCategoryWindow();
        _addCategoryWindow.Show();
    }

    private void UpdateNotes() {
        var filterupdate = NotesList.Where(note => note.Category == _selectedCategory);
        FilteredNotes = new ObservableCollection<Note>(filterupdate);
        CountNotes();
    }
    private void LoadAllNotes() {
        FilteredNotes.Clear();
        DisplayCategory = "All Notes";
        FilteredNotes = NotesList;
        CountNotes();
    }
    private void LoadFavoriteNotes() {
        var loadall = NotesList.Where(note => note.IsFavorite == true);
        FilteredNotes.Clear();
        DisplayCategory = "Favorites";
        FilteredNotes = new ObservableCollection<Note>(loadall);
        CountNotes();
    }

    private void CountNotes() {
        NumberNotes = FilteredNotes.Count();
    }

    public void DeleteNote() {
        NotesList.RemoveAt(SelectedNoteIndex);
    }

    public void IsFavStateChange() {
        if (SelectedNote.IsFavorite == false) {
            SelectedNote.IsFavorite = true;
        } else {
            SelectedNote.IsFavorite = false;
        }
    }

    public IReactiveCommand<Unit, Unit> AddCategoryOpenCommand { get; set; }
    public IReactiveCommand<Unit, Unit> DeleteNoteCommand { get; set; }
    public IReactiveCommand<Unit, Unit> IsFavNoteChangeCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadFavNoteCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadAllNotesCommand { get; set; }
}
