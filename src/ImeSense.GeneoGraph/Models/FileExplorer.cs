using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ImeSense.GeneoGraph.Models {
    public class FileExplorer
    {
        static readonly string dirName = @"E:\Programming\VStudio\geneograph\projects\project_1";

        public DirectoryInfo directory = new DirectoryInfo(dirName);

        public static ObservableCollection<string> FilesList => new();

        public FileExplorer() {
            if (Directory.Exists(dirName)) {
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs) {
                    FilesList.Add(s);
                }

                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files) {
                    FilesList.Add(s);
                }
            }
        }

        public static ObservableCollection<string> GetFiles => FilesList;
    }
}
