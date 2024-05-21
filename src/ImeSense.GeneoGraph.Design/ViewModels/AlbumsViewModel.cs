using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

using Avalonia.Controls;

using ImeSense.GeneoGraph.Design.Models;
using ImeSense.GeneoGraph.Design.Views;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels;

public class AlbumsViewModel : ReactiveObject {
    private Window? _addAlbumWindow;

    private bool _albumsOpen = true;
    private bool _infoOpen = true;
    private bool _connectionsOpen = false;
    private string? _shevronAlbumsRotation = "rotate(180deg)";
    private string? _shevronInfoRotation = "rotate(180deg)";
    private string? _shevronConnectionsRotation;

    private int _numberPhotos;
    private int _selectedPhotoIndex;
    private bool _rightDockVisibility = false;

    private PhotoAlbum _selectedAlbum;
    private Photo _selectedPhoto;

    public AlbumsViewModel() {
        _selectedAlbum = new PhotoAlbum();
        _selectedPhoto = new Photo();

        AlbumsList = PhotoAlbum.AlbumsList;
        PhotosList = Photo.PhotosList;

        AlbumsOpenCloseCommand = ReactiveCommand.Create(AlbumsOpenClose);
        InfoOpenCloseCommand = ReactiveCommand.Create(InfoOpenClose);
        ConnectionsOpenCloseCommand = ReactiveCommand.Create(ConnectionsOpenClose);
        AddAlbumOpenCommand = ReactiveCommand.Create(AddAlbumOpen);
        IsFavPhotoChangeCommand = ReactiveCommand.Create(IsFavStateChange);
        LoadFavPhotosCommand = ReactiveCommand.Create(LoadFavoritePhotos);
        LoadAllPhotosCommand = ReactiveCommand.Create(LoadAllPhotos);

        this.WhenAnyValue(x => x.SelectedPhotoIndex)
            .Skip(1) // Skip initial null value
            .Where(index => index >= 0)
            .Subscribe(_ => RightDockVisibility = true);

        this.WhenAnyValue(x => x.SelectedPhotoIndex)
            .Skip(1) // Skip initial null value
            .Where(index => index < 0)
            .Subscribe(_ => RightDockVisibility = false);

        this.WhenAnyValue(x => x.SelectedAlbum)
            .Subscribe(_ => DisplayCategory = SelectedAlbum.AlbumName);

        LoadAllPhotos();

        LoadImages();
    }

    [Reactive]
    public ObservableCollection<Photo> FilteredPhotos { get; set; } = new();

    [Reactive]
    public ObservableCollection<PhotoAlbum> AlbumsList { get; set;} = new();
    [Reactive]
    public ObservableCollection<Photo> PhotosList { get; set; } = new();

    [Reactive]
    public string DisplayCategory { get; set; } = "All Photos";


    public PhotoAlbum SelectedAlbum {
        get => _selectedAlbum;
        set {
            this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
            UpdatePhotos();
        }
    }

    [Reactive]
    public Photo SelectedPhoto {
        get => _selectedPhoto;
        set => this.RaiseAndSetIfChanged(ref _selectedPhoto, value);
    }

    [Reactive]
    public bool AlbumsOpen {
        get => _albumsOpen;
        set => this.RaiseAndSetIfChanged(ref _albumsOpen, value);
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
    public string? ShevronAlbumsRotation {
        get => _shevronAlbumsRotation;
        set => this.RaiseAndSetIfChanged(ref _shevronAlbumsRotation, value);
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

    [Reactive]
    public int SelectedPhotoIndex {
        get => _selectedPhotoIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedPhotoIndex, value);
    }

    [Reactive]
    public bool RightDockVisibility {
        get => _rightDockVisibility;
        set => this.RaiseAndSetIfChanged(ref _rightDockVisibility, value);
    }

    [Reactive]
    public int NumberPhotos {
        get => _numberPhotos;
        set => this.RaiseAndSetIfChanged(ref _numberPhotos, value);
    }

    public void AlbumsOpenClose() {
        if (AlbumsOpen == true) {
            AlbumsOpen = false;
            ShevronAlbumsRotation = null;

        } else {
            AlbumsOpen = true;
            ShevronAlbumsRotation = "rotate(180deg)";
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
        public void AddAlbumOpen() {
        _addAlbumWindow = new AddAlbumWindow();
        _addAlbumWindow.Show();
    }

    private void UpdatePhotos() {
        var filterupdate = PhotosList.Where(photo => photo.Album == SelectedAlbum);
        FilteredPhotos = new ObservableCollection<Photo>(filterupdate);
        CountPhotos();
    }
    private void LoadAllPhotos() {
        if (DisplayCategory != "All Photos") {
            DisplayCategory = "All Photos";
            FilteredPhotos = PhotosList;
            CountPhotos();
        }
    }
    private void LoadFavoritePhotos() {
        if (DisplayCategory != "Favorites") {
            var loadall = PhotosList.Where(photo => photo.IsFavorite == true);
            DisplayCategory = "Favorites";
            FilteredPhotos = new ObservableCollection<Photo>(loadall);
            CountPhotos();
        }
    }

    private void CountPhotos() {
        NumberPhotos = PhotosList.Count();
    }

    public void IsFavStateChange() {
        if (SelectedPhoto.IsFavorite == false) {
            SelectedPhoto.IsFavorite = true;
        } else {
            SelectedPhoto.IsFavorite = false;
        }
    }

    public IReactiveCommand<Unit, Unit> AlbumsOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> InfoOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> IsFavPhotoChangeCommand { get; set; }
    public IReactiveCommand<Unit, Unit> ConnectionsOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> AddAlbumOpenCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadFavPhotosCommand { get; set; }
    public IReactiveCommand<Unit, Unit> LoadAllPhotosCommand { get; set; }

    private void LoadImages() 
    {
        foreach (var photo in PhotosList) {
            photo.LoadImage();
        }
    }
}
