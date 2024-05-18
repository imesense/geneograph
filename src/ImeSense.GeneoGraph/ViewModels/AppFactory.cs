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
    private IDocumentDock? _tabsDock;

    private readonly ProjectsViewModel _projectsViewModel;
    private readonly ApplicationTabsDock _applicationTabsDock;

    public AppFactory(ProjectsViewModel projectsViewModel,
        ApplicationTabsDock applicationTabsDock) {
        _projectsViewModel = projectsViewModel;
        _applicationTabsDock = applicationTabsDock;
    }

    public override IDocumentDock CreateDocumentDock() {
        return _applicationTabsDock;
    }

    public override IRootDock CreateLayout() {
        var emptyFileViewModel = _projectsViewModel;
        emptyFileViewModel.Title = "Projects";
        emptyFileViewModel.CanClose = false;

        // Tabs
        var tabsDock = _applicationTabsDock;
        tabsDock.Id = "Tabs";
        tabsDock.Title = "Tabs";
        tabsDock.IsCollapsable = false;
        tabsDock.Proportion = double.NaN;
        tabsDock.ActiveDockable = emptyFileViewModel;
        tabsDock.VisibleDockables = CreateList<IDockable>(emptyFileViewModel);
        tabsDock.CanCreateDocument = false;

        var windowLayout = CreateRootDock();
        windowLayout.Title = "Geneograph";
        windowLayout.IsCollapsable = false;

        // Content
        var windowLayoutContent = new ProportionalDock {
            Orientation = Orientation.Horizontal,
            IsCollapsable = false,
            VisibleDockables = CreateList<IDockable>(tabsDock),
        };
        windowLayout.VisibleDockables = CreateList<IDockable>(windowLayoutContent);
        windowLayout.ActiveDockable = windowLayoutContent;

        // Root
        var rootDock = CreateRootDock();
        rootDock.IsCollapsable = false;
        rootDock.VisibleDockables = CreateList<IDockable>(windowLayout);
        rootDock.ActiveDockable = windowLayout;
        rootDock.DefaultDockable = windowLayout;

        _tabsDock = tabsDock;
        _rootDock = rootDock;

        return rootDock;
    }

    public override void InitLayout(IDockable layout) {
        DockableLocator = new Dictionary<string, Func<IDockable?>> {
            ["Root"] = () => _rootDock,
            ["Tabs"] = () => _tabsDock,
        };

        HostWindowLocator = new Dictionary<string, Func<IHostWindow?>> {
            [nameof(IDockWindow)] = () => new HostWindow(),
        };

        base.InitLayout(layout);
    }
}
