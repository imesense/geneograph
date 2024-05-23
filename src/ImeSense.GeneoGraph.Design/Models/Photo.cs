using System;
using System.Collections.ObjectModel;

using Avalonia.Media.Imaging;

using ImeSense.GeneoGraph.Design.Models;
using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.Models;

public class Photo : ReactiveObject {

    private string _filePath = string.Empty;
    private Bitmap _photoBitmap;

    public int PhotoId { get; set; }
    public string PhotoName { get; set; } = string.Empty;
    public PhotoAlbum Album { get; set; } = PhotoAlbum.AlbumsList[0];
    public DateTime? PhotoDate { get; set; }
    public Source? PhotoSource { get; set; }
    public Location? PhotoLocation { get; set; }
    public string? PhotoNotes { get; set; }
    public bool IsFavorite { get; set; } = false;

    public DateTime PhotoAddedTime { get; set; }

    public Bitmap PhotoBitmap {
        get => _photoBitmap;
        private set => this.RaiseAndSetIfChanged(ref _photoBitmap, value);
    }

    public string FilePath {
        get => _filePath;
        set => this.RaiseAndSetIfChanged(ref _filePath, value);
    }

    public void LoadImage() {
        if (Uri.TryCreate(_filePath, UriKind.RelativeOrAbsolute, out var uri)) {
            PhotoBitmap = ImageHelper.LoadFromResource(uri);
        } else {
            var defaultUriPath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture.png"; //Loading some default image if there is none
            Uri.TryCreate(defaultUriPath, UriKind.RelativeOrAbsolute, out var defaulturi);
            PhotoBitmap = ImageHelper.LoadFromResource(defaulturi);
        }
    }

    public static ObservableCollection<Photo> PhotosList { get; set; } = new()
{
        new Photo
        {
            PhotoId = 1,
            PhotoName = "Test Photo Name",
            Album = PhotoAlbum.AlbumsList[0],
            PhotoSource= Source.ListSources[0],
            PhotoLocation = Location.ListLocations[0],
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            PhotoAddedTime = DateTime.Now,
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture.png",
        },
        new Photo
        {
            PhotoId = 2,
            PhotoName = "Silver Cat",
            Album = PhotoAlbum.AlbumsList[2],
            PhotoSource= Source.ListSources[1],
            PhotoLocation = Location.ListLocations[1],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "This is a picture of Silver, one of our cats",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture2.png",
            IsFavorite = true

        },
        new Photo
        {
            PhotoId = 3,
            PhotoName = "Michelle Cat",
            Album = PhotoAlbum.AlbumsList[3],
            PhotoSource= Source.ListSources[2],
            PhotoLocation = Location.ListLocations[2],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "This is a picture of Misha, one of our cats",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture3.png",
            IsFavorite = true

        },
        new Photo
        {
            PhotoId = 3,
            PhotoName = "Sima Cat",
            Album = PhotoAlbum.AlbumsList[3],
            PhotoSource= Source.ListSources[2],
            PhotoLocation = Location.ListLocations[2],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "This is a picture of Sima, one of our cats",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture4.png",
            IsFavorite = true

        },
    };

}
