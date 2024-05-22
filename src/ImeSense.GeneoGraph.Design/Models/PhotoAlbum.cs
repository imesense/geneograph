using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Design.Models;

public class PhotoAlbum 
{
    /// <summary>
    /// Maybe we can create a single class for Albums and Note Categories, they will likely have the same parameters. To be discussed
    /// </summary>
    public int AlbumId { get; set; }

    public string AlbumName { get; set; } = string.Empty;

    public override string ToString() {
        return AlbumName;
    }

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
}
