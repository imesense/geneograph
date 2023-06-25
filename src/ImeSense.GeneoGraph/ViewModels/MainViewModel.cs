using CommunityToolkit.Mvvm.ComponentModel;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ObservableObject {
    private object _currentViewModel;

    public object CurrentViewModel {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }

    public MainViewModel() {
        CurrentViewModel = new PeopleViewModel();
    }
}
