using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;

namespace ImeSense.GeneoGraph.Models {
    public class FileExplorer
    {
        public static List<string> ListDirectory(string? dirName)
        {
            DirectoryInfo directory = new DirectoryInfo(dirName);
            return directory.GetDirectories().Select(x => x.Name).ToList();

        }
        public static List<string> ListFiles(string? dirName)
        {
            DirectoryInfo directory = new DirectoryInfo(dirName);
            return directory.GetFiles().Select(x => x.Name).ToList();

        }

    }
}
