using System;
using System.Collections.Generic;

using Dock.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;
using Dock.Model.ReactiveUI;
using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.ViewModels.Docks;
using ImeSense.GeneoGraph.ViewModels.Documents;

namespace ImeSense.GeneoGraph.ViewModels;

public class AppFactory : Factory {
    private IRootDock? _rootDock;
    private IDocumentDock? _documentDock;

    public override IDocumentDock CreateDocumentDock() {
        return new FileDocumentDock();
    }

    public override IRootDock CreateLayout() {
        var emptyFileViewModel = new FileViewModel {
            Title = "Projects",
            CanClose = false,
        };

        // Tabs
        var documentDock = new FileDocumentDock {
            Id = "Files",
            Title = "Files",
            IsCollapsable = false,
            Proportion = double.NaN,
            ActiveDockable = emptyFileViewModel,
            VisibleDockables = CreateList<IDockable>(emptyFileViewModel),
            CanCreateDocument = false,
        };

        var windowLayout = CreateRootDock();
        windowLayout.Title = "Default";
        windowLayout.IsCollapsable = false;

        // Content
        var windowLayoutContent = new ProportionalDock {
            Orientation = Orientation.Horizontal,
            IsCollapsable = false,
            VisibleDockables = CreateList<IDockable>(documentDock),
        };
        windowLayout.VisibleDockables = CreateList<IDockable>(windowLayoutContent);
        windowLayout.ActiveDockable = windowLayoutContent;

        // Root
        var rootDock = CreateRootDock();
        rootDock.IsCollapsable = false;
        rootDock.VisibleDockables = CreateList<IDockable>(windowLayout);
        rootDock.ActiveDockable = windowLayout;
        rootDock.DefaultDockable = windowLayout;

        _documentDock = documentDock;
        _rootDock = rootDock;

        return rootDock;
    }

    public override void InitLayout(IDockable layout) {
        DockableLocator = new Dictionary<string, Func<IDockable?>> {
            ["Root"] = () => _rootDock,
            ["Tabs"] = () => _documentDock,
        };

        HostWindowLocator = new Dictionary<string, Func<IHostWindow?>> {
            [nameof(IDockWindow)] = () => new HostWindow(),
        };

        base.InitLayout(layout);
    }
}
