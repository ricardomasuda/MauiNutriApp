using System.Collections.ObjectModel;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.View.Food.Detail;

namespace NutriApp.AppNutri.View.Food.List;

public class FoodListViewModel : BaseViewModel
{
    private ObservableCollection<FoodModel> _listFood;
    public ObservableCollection<FoodModel> ListFood { get => _listFood; set { _listFood = value; OnPropertyChanged("ListFood"); } }
        
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
        try
        {
            ListFood = await DataBaseService.GetFoods();
            _listFoodAux = ListFood;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
      
    }

    private void GoBack()
    {
        App.NavPage.PopAsync();
    }

    private void SearchBarAction()
    {
        var list = string.IsNullOrEmpty(SearchBar) ? _listFoodAux : _listFoodAux.Where(x => x.Nome.ToUpper().Contains(SearchBar.ToUpper()));
        ListFood = new ObservableCollection<FoodModel>(list.ToList());
    }

    private static async void EditFood(object sender)
    {
        await Navigation.PushPageAsync(new FoodDetailPage((FoodModel)sender));
    }

    private async void AddFood(object sender)
    {
        await App.NavPage.DisplayAlert("Em contrução", "Pagina em construção", "OK");
    }
}