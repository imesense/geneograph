using System.Threading.Tasks;

using Avalonia.Platform.Storage;

using ImeSense.GeneoGraph.ViewModels;

namespace ImeSense.GeneoGraph.Services;

public class FilesService : IFilesService
{
    private static FilePickerFileType ProjectsFilePickerFileType { get; } = new("GeneoGraph Projects")
    {
        Patterns = new[] {
            "*.ggph",
            "*.json",
        },
        AppleUniformTypeIdentifiers = new[] {
            "public.project",
        },
        MimeTypes = new[] {
            "text/*",
        },
    };

    public async Task<IStorageFile?> OpenFileAsync()
    {
        var files = await StorageLocator.StorageProvider
            .OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                Title = "Open file",
                AllowMultiple = false,
                FileTypeFilter = new[] {
                    ProjectsFilePickerFileType,
                },
            });
        return files.Count >= 1
            ? files[0]
            : null;
    }

    public async Task<IStorageFile?> SaveFileAsync()
    {
        return await StorageLocator.StorageProvider
            .SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                Title = "Save file",
                DefaultExtension = "ggph",
                FileTypeChoices = new[] {
                    ProjectsFilePickerFileType,
                },
            });
    }
}
