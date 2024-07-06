using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.SelectFood;

public partial class ChangeFoodPopupViewModel : BaseViewModel
{
    private const double COLLECTION_VIEW_BOTTOM_PADDING = 20;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SearchBarActionCommand))]
    private string _searchBar;

    [ObservableProperty] private ObservableCollection<FoodModel> _foods = [];
    [ObservableProperty] private double _collectionViewHeight;
    [ObservableProperty] private double _searchTitleHeight;
    [ObservableProperty] private double _collectionViewCellHeight;
    private ObservableCollection<FoodModel> _listFoodAux;
    public Command GoBackCommand { get; set; }
    public SelectFoodPopupViewModel FoodDetailViewModel { get; set; }
    private ChangeFoodPopup _changeFoodPopup;

    public ChangeFoodPopupViewModel(SelectFoodPopupViewModel foodDetailViewModel, ChangeFoodPopup changeFoodPopup)
    {
        FoodDetailViewModel = foodDetailViewModel;
        _changeFoodPopup = changeFoodPopup;
        GoBackCommand = new Command(() => Shell.Current.Navigation.PopAsync());
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
    private async void SelectFood(object sender)
    {
        var food = (FoodModel)sender;
        FoodDetailViewModel.Food = food;
        FoodDetailViewModel.Measure = Convert.ToDouble(food.Medida);
        _changeFoodPopup.Close();
        //await App.NavPage.Navigation.PopPopupAsync();
    }
    
    [RelayCommand]
    private void SearchBarAction() {
        IEnumerable<FoodModel> list = string.IsNullOrEmpty(SearchBar)
            ? _listFoodAux
            : _listFoodAux.Where(food => food.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        Foods = [..list.ToList()];
    }
    protected override void OnPropertyChanged(PropertyChangedEventArgs e) {
        base.OnPropertyChanged(e);

        if (e.PropertyName is nameof(SearchTitleHeight) or nameof(CollectionViewCellHeight)) {
            CollectionViewHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density -
                                   SearchTitleHeight - CollectionViewCellHeight - COLLECTION_VIEW_BOTTOM_PADDING;
        }
    }
}