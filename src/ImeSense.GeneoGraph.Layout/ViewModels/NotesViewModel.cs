using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Layout.Models;
using ImeSense.GeneoGraph.Layout.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Layout.ViewModels;

public class NotesViewModel : ReactiveObject {
    private Window? _addCategoryWindow;

    private bool _categoriesOpen = true;
    private bool _infoOpen = true;
    private bool _connectionsOpen = false;
    private string? _shevronCategoriesRotation = "rotate(180deg)";
    private string? _shevronInfoRotation = "rotate(180deg)";
    private string? _shevronConnectionsRotation;

    private int _numberNotes = 0;
    public int _selectedNoteIndex;
    private bool _rightDockVisibility = false;

    public Interaction<NotesViewModel, AddNoteViewModel?> ShowDialog { get; }
    public ReactiveCommand<AddNoteViewModel?, Unit> AddNewNoteCommand { get; }
    public ICommand AddNoteOpenCommand { get; }

    public NotesViewModel() {
        _selectedCategory = new NoteCategory();
        _selectedNote = new Note();

        CategoryList = NoteCategory.CategoryList;

        NotesList = Note.NotesList;

        CategoriesOpenCloseCommand = ReactiveCommand.Create(CategoriesOpenClose);
        InfoOpenCloseCommand = ReactiveCommand.Create(InfoOpenClose);
        ConnectionsOpenCloseCommand = ReactiveCommand.Create(ConnectionsOpenClose);
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

    [Reactive]
    public bool CategoriesOpen {
        get => _categoriesOpen;
        set => this.RaiseAndSetIfChanged(ref _categoriesOpen, value);
    }

    [Reactive]
    public bool InfoOpen {
        get => _infoOpen;
        set => this.RaiseAndSetIfChanged(ref _infoOpen, value);
    }

    [Reactive]
    public bool ConnectionsOpen {
        get => _connectionsOpen;
        set => this.RaiseAndSetIfChanged(ref _connectionsOpen, value);
    }

    [Reactive]
    public string? ShevronCategoriesRotation {
        get => _shevronCategoriesRotation;
        set => this.RaiseAndSetIfChanged(ref _shevronCategoriesRotation, value);
    }

    [Reactive]
    public string? ShevronInfoRotation {
        get => _shevronInfoRotation;
        set => this.RaiseAndSetIfChanged(ref _shevronInfoRotation, value);
    }

    [Reactive]
    public string? ShevronConnectionsRotation {
        get => _shevronConnectionsRotation;
        set => this.RaiseAndSetIfChanged(ref _shevronConnectionsRotation, value);
    }

    public void AddCategoryOpen() {
        _addCategoryWindow = new AddCategoryWindow();
        _addCategoryWindow.Show();
    }

    private void UpdateNotes() {
        var filterupdate = NotesList.Where(note => note.Category == SelectedCategory);
        FilteredNotes = new ObservableCollection<Note>(filterupdate);
        CountNotes();
    }
    private void LoadAllNotes() {
        if (DisplayCategory != "All Notes")
        {
            DisplayCategory = "All Notes";
            FilteredNotes = NotesList;
            CountNotes();
        }
    }
    private void LoadFavoriteNotes() {
        if (DisplayCategory != "Favorites") {
            var loadall = NotesList.Where(note => note.IsFavorite == true);
            DisplayCategory = "Favorites";
            FilteredNotes = new ObservableCollection<Note>(loadall);
            CountNotes();
        }
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

    public void CategoriesOpenClose() {
        if (CategoriesOpen == true) {
            CategoriesOpen = false;
            ShevronCategoriesRotation = null;

        } else {
            CategoriesOpen = true;
            ShevronCategoriesRotation = "rotate(180deg)";
        }

    }
    public void InfoOpenClose() {
        if (InfoOpen == true) {
            InfoOpen = false;
            ShevronInfoRotation = null;

        } else {
            InfoOpen = true;
            ShevronInfoRotation = "rotate(180deg)";
        }

    }
    public void ConnectionsOpenClose() {
        if (ConnectionsOpen == true) {
            ConnectionsOpen = false;
            ShevronConnectionsRotation = null;

        } else {
            ConnectionsOpen = true;
            ShevronConnectionsRotation = "rotate(180deg)";
        }

    }

    public IReactiveCommand<Unit, Unit> AddCategoryOpenCommand { get; set; }
    public IReactiveCommand<Unit, Unit> DeleteNoteCommand { get; set; }
    public IReactiveCommand<Unit, Unit> IsFavNoteChangeCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadFavNoteCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadAllNotesCommand { get; set; }
    public IReactiveCommand<Unit, Unit> CategoriesOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> InfoOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> ConnectionsOpenCloseCommand { get; set; }
}
