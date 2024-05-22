using System;
using System.Collections.ObjectModel;

using Avalonia.Media.Imaging;

using ImeSense.GeneoGraph.Design.Models;
using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.Models;

public class Photo : ReactiveObject {

    private string _filePath = string.Empty;
    private Bitmap? _photoBitmap;

    public int PhotoId { get; set; }
    public string PhotoName { get; set; } = string.Empty;
    public PhotoAlbum? Album { get; set; } = new();
    public DateTime? PhotoDate { get; set; }
    public Source? PhotoSource { get; set; }
    public Location? PhotoLocation { get; set; }
    public string? PhotoNotes { get; set; }
    public bool IsFavorite { get; set; } = false;

    public DateTime PhotoAddedTime { get; set; }

    public Bitmap? PhotoBitmap {
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
            PhotoBitmap = null;
        }
    }

    public static ObservableCollection<Photo> PhotosList { get; set; } = new()
{
        new Photo
        {
            PhotoId = 1,
            PhotoName = "Test Photo Name",
            Album = PhotoAlbum.AlbumsList[0],
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            PhotoAddedTime = DateTime.Now,
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture.png",
        },
        new Photo
        {
            PhotoId = 2,
            PhotoName = "Another Test Photo name that is longer",
            Album = PhotoAlbum.AlbumsList[2],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture2.png"
            //PhotoBitmap = ImageHelper.LoadFromResource(new Uri("avares://Assets/Profile/Profile_picture.png"))
        },
        new Photo
        {
            PhotoId = 3,
            PhotoName = "An example of a very long photo name that is longer than the previous examples",
            Album = PhotoAlbum.AlbumsList[3],
            PhotoAddedTime = DateTime.Now,
            PhotoDate = DateTime.Now,
            PhotoNotes = "Lorem ipsum dolor",
            FilePath = "avares://ImeSense.GeneoGraph.Design/Assets/Profile/Profile_picture2.png"
            //PhotoBitmap = ImageHelper.LoadFromResource(new Uri("avares://Assets/Profile/Profile_picture.png"))
        },
    };

}
