using System;

using Avalonia.Media.Imaging;

using ImeSense.GeneoGraph.Design.Models;
using ReactiveUI;

namespace ImeSense.GeneoGraph.Design.Models;

public class Photo : ReactiveObject {

    private string _filePath = string.Empty;
    private Bitmap? _photoBitmap;

    public int PhotoId { get; set; }
    public string PhotoName { get; set; } = string.Empty;
    public PhotoAlbum? Album { get; set; }
    public DateTime? PhotoDate { get; set; }
    public Source? PhotoSource { get; set; }
    public string? PhotoPlace { get; set; }
    public string? PhotoNotes { get; set; }

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
}
