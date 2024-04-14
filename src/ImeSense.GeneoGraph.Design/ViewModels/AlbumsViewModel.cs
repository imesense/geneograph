using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

using ImeSense.GeneoGraph.Design.Models;

using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ImeSense.GeneoGraph.Design.ViewModels;

public class AlbumsViewModel : ReactiveObject 
{
    private bool _albumsOpen = true;
    private bool _infoOpen = true;
    private bool _connectionsOpen = false;
    private string? _shevronAlbumsRotation = "rotate(180deg)";
    private string? _shevronInfoRotation = "rotate(180deg)";
    private string? _shevronConnectionsRotation;

    public AlbumsViewModel() 
    {
        AlbumsOpenCloseCommand = ReactiveCommand.Create(AlbumsOpenClose);
        InfoOpenCloseCommand = ReactiveCommand.Create(InfoOpenClose);
        ConnectionsOpenCloseCommand = ReactiveCommand.Create(ConnectionsOpenClose);

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

    public void AlbumsOpenClose() 
    {
        if (AlbumsOpen == true) 
        {
            AlbumsOpen = false;
            ShevronAlbumsRotation = null;

        } 
        else 
        {
            AlbumsOpen = true;
            ShevronAlbumsRotation = "rotate(180deg)";
        }

    }
    public void InfoOpenClose() 
    {
        if (InfoOpen == true) 
        {
            InfoOpen = false;
            ShevronInfoRotation = null;

        } 
        else 
        {
            InfoOpen = true;
            ShevronInfoRotation = "rotate(180deg)";
        }

    }
    public void ConnectionsOpenClose() 
    {
        if (ConnectionsOpen == true) 
        {
            ConnectionsOpen = false;
            ShevronConnectionsRotation = null;

        } 
        else 
        {
            ConnectionsOpen = true;
            ShevronConnectionsRotation = "rotate(180deg)";
        }

    }

    public IReactiveCommand<Unit, Unit> AlbumsOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> InfoOpenCloseCommand { get; set; }
    public IReactiveCommand<Unit, Unit> ConnectionsOpenCloseCommand { get; set; }

    public ObservableCollection<PhotoAlbum> AlbumsList { get; set; } = new()
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
}
