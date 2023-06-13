using CommunityToolkit.Mvvm.ComponentModel;

namespace ImeSense.GeneoGraph.ViewModels;

public class MainViewModel : ObservableObject 
{
    private object _currentViewModel;

    public object CurrentViewModel {
        get { return _currentViewModel; }
        set { _currentViewModel = value; OnPropertyChanged(); }
    }

    public MainViewModel() {
        CurrentViewModel = new PeopleViewModel();

    }

}
