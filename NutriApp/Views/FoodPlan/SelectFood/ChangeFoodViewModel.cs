using System.Collections.ObjectModel;
using NutriApp.Components;
using NutriApp.Models;
using NutriApp.Services;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.SelectFood;

public class ChangeFoodViewModel : BaseViewModel
{
    private ObservableCollection<FoodModel> _listFood;
    public ObservableCollection<FoodModel> ListFood { get { return _listFood; } set { _listFood = value; OnPropertyChanged("ListFood"); } }
        
    private ObservableCollection<FoodModel> _listFoodAux;
        
    private string _searchBar;
    public string SearchBar { 
        get => _searchBar;
        set { _searchBar = value;
            SearchBarAction(); 
            OnPropertyChanged("SearchBar"); } 
    }
        
    public Command GoBackCommand { get; set; }
    public Command CloseCommand { get; set; }
    public Command SelectFoodCommand { get; set; }
    public SelectFoodPopupViewModel FoodDetailViewModel { get; set; }
    public ChangeFoodViewModel(SelectFoodPopupViewModel foodDetailViewModel)
    {
        FetchList();
        FoodDetailViewModel = foodDetailViewModel;
        //CloseCommand = new Command(async() => await App.NavPage.Navigation.PopPopupAsync());
        GoBackCommand = new Command(() => App.NavPage.PopAsync());
        SelectFoodCommand = new Command(SelectFood);
    }

    private async void FetchList()
    {
        ListFood = await DataBaseService.ListFoods();
        _listFoodAux = ListFood;
    }

    private async void SelectFood(object sender)
    {
        var food = (FoodModel)sender;
        FoodDetailViewModel.Food = food;
        FoodDetailViewModel.Measure = Convert.ToDouble(food.Medida);
        //await App.NavPage.Navigation.PopPopupAsync();
    }

    private void SearchBarAction()
    {
        var list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(x => x.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        ListFood = new ObservableCollection<FoodModel>(list.ToList());
    }
}