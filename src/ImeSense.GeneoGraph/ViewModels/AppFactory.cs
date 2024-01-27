using System;
using System.Collections.Generic;

using Dock.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;
using Dock.Model.ReactiveUI;
using Dock.Model.ReactiveUI.Controls;

using ImeSense.GeneoGraph.ViewModels.Docks;
using ImeSense.GeneoGraph.ViewModels.Documents;
using ImeSense.GeneoGraph.ViewModels.Tools;

namespace ImeSense.GeneoGraph.ViewModels;

public class AppFactory : Factory {
    private IRootDock? _rootDock;
    private IDocumentDock? _documentDock;
    private ITool? _listTool;
    private ITool? _propertiesTool;

    public override IDocumentDock CreateDocumentDock() {
        return new FileDocumentDock();
    }

    public override IRootDock CreateLayout() {
        var emptyFileViewModel = new FileViewModel();

        var peopleListViewModel = new PeopleListViewModel();
        var peoplePropertiesViewModel = new PeopleListViewModel();

        var documentDock = new FileDocumentDock {
            Id = "Files",
            Title = "Files",
            IsCollapsable = false,
            Proportion = double.NaN,
            ActiveDockable = emptyFileViewModel,
            VisibleDockables = CreateList<IDockable>(emptyFileViewModel),
            CanCreateDocument = true,
        };

        var toolDocks = new ProportionalDock {
            Proportion = 0.2,
            Orientation = Orientation.Vertical,
            VisibleDockables = CreateList<IDockable>(new ToolDock {
                ActiveDockable = peopleListViewModel,
                VisibleDockables = CreateList<IDockable>(peopleListViewModel),
                Alignment = Alignment.Right,
                GripMode = GripMode.Visible,
            },
            new ProportionalDockSplitter(),
            new ToolDock {
                ActiveDockable = peoplePropertiesViewModel,
                VisibleDockables = CreateList<IDockable>(peoplePropertiesViewModel),
                Alignment = Alignment.Right,
                GripMode = GripMode.Visible,
            }),
        };

        var windowLayout = CreateRootDock();
        windowLayout.Title = "Default";
        windowLayout.IsCollapsable = false;

        var windowLayoutContent = new ProportionalDock {
            Orientation = Orientation.Horizontal,
            IsCollapsable = false,
            VisibleDockables = CreateList<IDockable>(documentDock,
                new ProportionalDockSplitter(), toolDocks),
        };
        windowLayout.VisibleDockables = CreateList<IDockable>(windowLayoutContent);
        windowLayout.ActiveDockable = windowLayoutContent;

        var rootDock = CreateRootDock();
        rootDock.IsCollapsable = false;
        rootDock.VisibleDockables = CreateList<IDockable>(windowLayout);
        rootDock.ActiveDockable = windowLayout;
        rootDock.DefaultDockable = windowLayout;

        _documentDock = documentDock;
        _rootDock = rootDock;
        _listTool = peopleListViewModel;
        _propertiesTool = peoplePropertiesViewModel;

        return base.CreateLayout();
    }

    public override void InitLayout(IDockable layout) {
        ContextLocator = new Dictionary<string, Func<object?>> {
            ["People list"] = () => layout,
            ["People properties"] = () => layout,
        };

        DockableLocator = new Dictionary<string, Func<IDockable?>> {
            ["Root"] = () => _rootDock,
            ["Files"] = () => _documentDock,
            ["People list"] = () => _listTool,
            ["People properties"] = () => _propertiesTool,
        };

        HostWindowLocator = new Dictionary<string, Func<IHostWindow?>> {
            [nameof(IDockWindow)] = () => new HostWindow()
        };

        base.InitLayout(layout);
    }
}
