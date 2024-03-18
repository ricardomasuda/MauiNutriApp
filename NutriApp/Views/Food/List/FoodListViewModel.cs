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

    private void SearchBarAction()
    {
        var list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(x => x.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        ListFood = new ObservableCollection<FoodModel>(list.ToList());
    }

    private static async void EditFood(object sender)
    {
        await Navigation.Navigation.PushPageAsync(new FoodDetailPage((FoodModel)sender));
    }

    private async void AddFood(object sender)
    {
        await App.NavPage.DisplayAlert("Em contrução", "Pagina em construção", "OK");

    [RelayCommand]
    private static void GoBack() => App.NavPage.PopAsync();

    protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
        base.OnPropertyChanged(e);

        if (e.PropertyName is nameof(SearchTitleHeight) or nameof(CollectionViewCellHeight)) {
            CollectionViewHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density -
                                   SearchTitleHeight - CollectionViewCellHeight - COLLECTION_VIEW_BOTTOM_PADDING;
        }
    }
}