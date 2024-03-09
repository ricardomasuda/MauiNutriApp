using System.Collections.ObjectModel;
using MvvmHelpers;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.View.Food.Detail;
using BaseViewModel = NutriApp.AppNutri.Componente.BaseViewModel;

namespace NutriApp.AppNutri.View.Food.List;

public class FoodListViewModel : BaseViewModel
{
    private ObservableRangeCollection<FoodModel> _listFood;
    public ObservableRangeCollection<FoodModel> ListFood { get => _listFood; set { _listFood = value; OnPropertyChanged("ListFood"); } }
        
    private ObservableCollection<FoodModel> _listFoodAux;
        
    private string _searchBar;
    public string SearchBar { get => _searchBar; set { _searchBar = value; SearchBarAction(); OnPropertyChanged("SearchBar"); } }
    public Command GoEditFoodCommand  { get; set; }
    public Command GoAddFoodCommand { get; set; }
    public Command GoBackCommand { get; set; }
    public FoodListViewModel()
    {
        FetchList();
        GoEditFoodCommand = new Command(EditFood);
        GoAddFoodCommand = new Command(AddFood);
        GoBackCommand = new Command(GoBack);
    }

    private async void FetchList()
    {
        ListFood = new ObservableRangeCollection<FoodModel>();
        var listFoodItem = await DataBaseService.GetFoods();
        ListFood.AddRange(listFoodItem);
        _listFoodAux = ListFood;
    }

    private void GoBack()
    {
        App.NavPage.PopAsync();
    }

    private void SearchBarAction()
    {
        var list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(x => x.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        ListFood = new ObservableRangeCollection<FoodModel>(list.ToList());
    }

    private static async void EditFood(object sender)
    {
        var navigationParameter = new ShellNavigationQueryParameters
        {
            { "food", (FoodModel)sender }
        };
        await Shell.Current.GoToAsync(nameof(FoodDetailPage), navigationParameter);
    }

    private async void AddFood(object sender)
    {
        await App.NavPage.DisplayAlert("Em contrução", "Pagina em construção", "OK");
    }
}