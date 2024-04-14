using System;
using Avalonia.Media.Imaging;

namespace ImeSense.GeneoGraph.Design.Models;

public class Photo {
    public int PhotoId { get; set; }
    public string PhotoName { get; set; } = string.Empty;
    public string PhotoLocation { get; set; } = string.Empty;
    public PhotoAlbum? Album { get; set; }
    public Bitmap? PhotoBitmap { get; set; }

    public DateTime? PhotoDate { get; set; }
    public Source? PhotoSource { get; set; }
    public string? PhotoPlace { get; set; }
    public string? PhotoNotes { get; set; }

    public DateTime PhotoAddedTime { get; set; }
}
