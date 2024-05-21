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

    private PhotoAlbum? _selectedAlbum;
    private Photo? _selectedPhoto;

    public AlbumsViewModel() {
        AlbumsOpenCloseCommand = ReactiveCommand.Create(AlbumsOpenClose);
        InfoOpenCloseCommand = ReactiveCommand.Create(InfoOpenClose);
        ConnectionsOpenCloseCommand = ReactiveCommand.Create(ConnectionsOpenClose);
        AddAlbumOpenCommand = ReactiveCommand.Create(AddAlbumOpen);

        this.WhenAnyValue(x => x.SelectedPhotoIndex)
            .Skip(1) // Skip initial null value
            .Where(index => index >= 0)
            .Subscribe(_ => RightDockVisibility = true);

        this.WhenAnyValue(x => x.SelectedPhotoIndex)
            .Skip(1) // Skip initial null value
            .Where(index => index < 0)
            .Subscribe(_ => RightDockVisibility = false);

        NumberPhotos = PhotosList.Count();

        LoadImages();
    }

    [Reactive]
    public PhotoAlbum? SelectedAlbum {
        get => _selectedAlbum;
        set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
    }

    [Reactive]
    public Photo? SelectedPhoto {
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

    public IReactiveCommand<Unit, Unit> AlbumsOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> InfoOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> ConnectionsOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> AddAlbumOpenCommand { get; set; }

    public static ObservableCollection<PhotoAlbum> AlbumsList { get; set; } = new()
    {
        new PhotoAlbum
        {
            AlbumId = 1,
            AlbumName = "Album 1",
        },
        new PhotoAlbum
        {
            AlbumId = 2,
            AlbumName = "Album 2",
        },
        new PhotoAlbum
        {
            AlbumId = 3,
            AlbumName = "Album 3",
        },
        new PhotoAlbum
        {
            AlbumId = 4,
            AlbumName = "Album 4",
        },
        new PhotoAlbum
        {
            AlbumId = 5,
            AlbumName = "Album 5",
        },
    };

    public ObservableCollection<Photo> PhotosList { get; set; } = new()
    {
        new Photo
        {
            PhotoId = 1,
            PhotoName = "Test Photo Name",
            Album = AlbumsList.FirstOrDefault(),
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            PhotoPlace = "Nowhere",
            PhotoAddedTime = DateTime.Now,
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture.png",
        },
        new Photo
        {
            PhotoId = 2,
            PhotoName = "Another Test Photo name that is longer",
            Album = AlbumsList[2],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            PhotoPlace = "Anywhere",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture2.png"
            //PhotoBitmap = ImageHelper.LoadFromResource(new Uri("avares://Assets/Profile/Profile_picture.png"))
        },
        new Photo
        {
            PhotoId = 3,
            PhotoName = "An example of a very long photo name that is longer than the previous examples",
            Album = AlbumsList[3],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            PhotoPlace = "Somewhere",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture2.png"
            //PhotoBitmap = ImageHelper.LoadFromResource(new Uri("avares://Assets/Profile/Profile_picture.png"))
        },
    };

    private void LoadImages() 
    {
        foreach (var photo in PhotosList) {
            photo.LoadImage();
        }
    }
}
