using Avalonia.Platform.Storage;
using System.Threading.Tasks;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.Managers;

public interface IProjectManager
{
    Project? Project { get; set; }

    Task CreateProjectAsync(IStorageFile file);

    Task<Project> ReadProjectAsync(IStorageFile file);
}
