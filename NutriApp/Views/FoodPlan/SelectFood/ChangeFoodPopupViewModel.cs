using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.SelectFood;

public partial class ChangeFoodPopupViewModel : BaseViewModel
{
    private const double COLLECTION_VIEW_BOTTOM_PADDING = 80;

    [ObservableProperty] 
    [NotifyCanExecuteChangedFor(nameof(SearchBarActionCommand))]
    private string _searchBar;

    [ObservableProperty] private ObservableCollection<FoodModel> _foods = [];
    [ObservableProperty] private double _collectionViewHeight;
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
        CollectionViewHeight = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density) * 0.6;
    }

    [RelayCommand]
    private async void SelectFood(object sender)
    {
        var food = (FoodModel)sender;
        FoodDetailViewModel.Food = food;
        FoodDetailViewModel.Measure = Convert.ToDouble(food.Medida);
        //_changeFoodPopup.Close();
        await App.NavPage.GoBackModal();
    }
    
    [RelayCommand]
    private void SearchBarAction() {
        if (_listFoodAux is null) return;
        IEnumerable<FoodModel> list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(food => food.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        Foods = [..list.ToList()];
    }
}