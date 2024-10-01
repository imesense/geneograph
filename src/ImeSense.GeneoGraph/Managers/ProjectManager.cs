using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Avalonia.Platform.Storage;

using ImeSense.GeneoGraph.Models;

namespace ImeSense.GeneoGraph.Managers;

public class ProjectManager : IProjectManager
{
    public Project? Project { get; set; }

    public async Task CreateProjectAsync(IStorageFile file)
    {
        var project = new Project
        {
            Name = file.Name,
        };
        var json = JsonSerializer.Serialize(project);
        var stream = new MemoryStream(Encoding.Default.GetBytes(json));
        await using var writeStream = await file.OpenWriteAsync();
        await stream.CopyToAsync(writeStream);
    }

    public async Task<Project> ReadProjectAsync(IStorageFile file)
    {
        await using var readStream = await file.OpenReadAsync();
        using var streamReader = new StreamReader(readStream);
        var json = await streamReader.ReadToEndAsync();
        var project = JsonSerializer.Deserialize<Project>(json);
        return project is not null
            ? project
            : new Project();
    }
}
