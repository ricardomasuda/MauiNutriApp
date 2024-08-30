using NutriApp.Views.Food.Detail;

namespace NutriApp.Views.Food.List;

public partial class FoodListViewModel : BaseViewModel {
    private const double COLLECTION_VIEW_BOTTOM_PADDING = 20;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SearchBarActionCommand))]
    private string _searchBar;

    [ObservableProperty] private ObservableCollection<FoodModel> _foods = [];
    [ObservableProperty] private double _collectionViewHeight;
    [ObservableProperty] private double _searchTitleHeight;
    [ObservableProperty] private double _collectionViewCellHeight;

    private ObservableCollection<FoodModel> _listFoodAux;

    public FoodListViewModel() {
        MainThread.InvokeOnMainThreadAsync(FetchFoods);
    }

    private async Task FetchFoods() {
        if (IsBusy) return;
        IsBusy = true;

        ObservableCollection<FoodModel> foodsResult = await DataBaseService.ListFoods();

        if (Foods.Count is not 0) Foods.Clear();
        Foods = foodsResult;
        _listFoodAux = Foods;

        IsBusy = false;
    }

    [RelayCommand]
    private void SearchBarAction() {
        if (_listFoodAux is null) return;
        IEnumerable<FoodModel> list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(food => food.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        Foods = [..list.ToList()];
    }

    [RelayCommand]
    private async Task EditFood(object sender) {
        ShellNavigationQueryParameters navigationParameter = new() {
            { "Food", (FoodModel)sender }
        };

        await Shell.Current.GoToAsync(nameof(FoodDetailPage), navigationParameter);
    }

    [RelayCommand]
    private async Task AddFood(object sender) =>
        await Shell.Current.DisplayAlert("Em contrução", "Pagina em construção", "OK");

    [RelayCommand]
    private static void GoBack() => Shell.Current.Navigation.PopAsync();

    protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
        base.OnPropertyChanged(e);

        if (e.PropertyName is nameof(SearchTitleHeight) or nameof(CollectionViewCellHeight)) {
            CollectionViewHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density -
                                   SearchTitleHeight - CollectionViewCellHeight - COLLECTION_VIEW_BOTTOM_PADDING;
        }
    }
}