using Avalonia.Platform.Storage;

namespace ImeSense.GeneoGraph.ViewModels;

public static class StorageLocator {
    public static IStorageProvider StorageProvider { get; set; } = null!;
}
