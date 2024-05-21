using Avalonia.Controls;


namespace ImeSense.GeneoGraph.Design.Views;

public partial class MapView : UserControl {

    public MapView() {
        InitializeComponent();

        var mapControl = new Mapsui.UI.Avalonia.MapControl();
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());
        Content = mapControl;
    }
}
