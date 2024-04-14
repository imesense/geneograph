using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImeSense.GeneoGraph.Design.Models;

public class PhotoAlbum 
{
    public int AlbumId { get; set; }

    public string AlbumName { get; set; } = string.Empty;

    public override string ToString() {
        return AlbumName;
    }

}
