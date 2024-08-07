using NutriApp.Views.FoodPlan.FoodDetail.SelectList;
using NutriApp.Views.FoodPlan.MealList;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.FoodDetail;

[QueryProperty(nameof(MealModel), nameof(MealModel))]
[QueryProperty(nameof(FoodPlanDetailPageViewModel), nameof(FoodPlanDetailPageViewModel))]
public partial class MealFoodDetailViewModel : BaseViewModel
{
    [ObservableProperty] private FoodModel _foodTotal;
    [ObservableProperty] private ObservableCollection<FoodModel> _listFood;
    [ObservableProperty] private Item _itemMeal;
    [ObservableProperty] private ObservableCollection<Item> _listItemMeal;
    [ObservableProperty] private string _title;
    [ObservableProperty] private TypeTitleEnum _titleType;
    [ObservableProperty] private TimeSpan _hour;
    [ObservableProperty] private bool _hasErrorHour;
    [ObservableProperty] private bool _canSeeReport;
    [ObservableProperty] private bool _hasErrorItemMeal;
    [ObservableProperty] private bool _haveList;

    private MealModel _meal;
    private FoodPlanDetailPageViewModel _foodPlanDetailPageViewModel;

    public MealFoodDetailViewModel()
    {
        Fetch();
    }
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _foodPlanDetailPageViewModel = query[nameof(FoodPlanDetailPageViewModel)] as FoodPlanDetailPageViewModel;
        _meal = query[nameof(MealModel)] as MealModel;
        Fetch();
    }

    private async void Fetch()
    {
        ListItemMeal = new MealModel().MealType();
        ListFood = new ObservableCollection<FoodModel>();
        if (_meal != null)
        {
            Title = "Atualizar Refeição";
            TitleType = TypeTitleEnum.Trash;
            Hour = TimeSpan.Parse(_meal.Horario);
            ListFood = await DataBaseService.GetFoodWhere(_meal.Id);
            HaveList = ListFood.Count != 0;
            CanSeeReport = HaveList;
        }
        else
        {
            Title = "Salvar Refeição";
            CanSeeReport = false;
            TitleType = TypeTitleEnum.None;
        }

        TotalValue();
        FoodService.AddUnitMeasureList(ListFood);
    }

    public void SaveFoodList(FoodModel food)
    {
        ListFood.Add(FoodService.AddUnitMeasureToValues(food));
        TotalValue();
    }
    
    public void UpdateFoodList(FoodModel newFood, FoodModel oldFood)
    {
        if (oldFood.Id != newFood.Id)
        {
            _ = RemoveFood(oldFood);
            SaveFoodList(newFood);
        }
        else if (ListFood.Contains(oldFood))
        {
            var indexFood = ListFood.IndexOf(oldFood);
            _ = RemoveFood(oldFood);
            ListFood.Insert(indexFood, newFood);
        }

        TotalValue();
    }

    [RelayCommand]
    private async Task DeleteMeal()
    {
        if (!await Shell.Current.DisplayAlert("Apagar Refeição", "Você deseja apagar refeição", "Sim", "Não"))
            return;
        await new MealDB().ExcluirTotalAsync(_meal.Id);

        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private void GoReport()
    {
        List<FoodModel> listFood = ListFood.Select(FoodService.RemoveUnitMeasurement).ToList();
        //App.NavPage.PushAsync(new ReportPage(listFood, ItemMeal.Nome));
    }

    [RelayCommand]
    public async Task RemoveFood(object obj)
    {
        FoodModel food = (FoodModel)obj;
        if (food.MealFoodId == 0)
        {
            ListFood.Remove(food);
            TotalValue();
        }
        else if (await new MealFoodDB().ExcluirAsync(food.MealFoodId) != 0)
        {
            ListFood.Remove(food);
            TotalValue();
        }
    }

    [RelayCommand]
    private async Task AddOrEditFood(object obj)
    {
        FoodModel food = (FoodModel)obj;
        await App.NavPage.ShowPopup(new SelectFoodPopup(this, food));
    }

    [RelayCommand]
    private async Task Save()
    {
        if (!Validate()) return;

        RemoveFoodTotal();
        MealModel mealModel = new MealModel
        {
            Id = _meal?.Id ?? 0,
            ListFood = new List<FoodModel>(ListFood),
            Nome = ItemMeal.Nome,
            //FoodPLanId = _foodPlanDetailViewModel.FoodPlanModel.Id,
            Horario = Hour.ToString()
        };

        if (!await Shell.Current.DisplayAlert($"{Title}", $"Você deseja {Title.ToLower()}", "Sim", "Não")) return;

        await new MealDB().SalvarAsync(mealModel);

        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task EditListFood()
    {
        await App.NavPage.ShowPopup(new SelectListFoodPopup(ListFood, this));
    }

    private void RemoveFoodTotal()
    {
        var foodModel = ListFood.FirstOrDefault(x => x.Nome == "Total:");
        ListFood.Remove(foodModel);
    }

    private bool Validate()
    {
        HasErrorHour = string.IsNullOrWhiteSpace(Hour.ToString());
        HasErrorItemMeal = ItemMeal == null;

        return (!HasErrorHour && !HasErrorItemMeal);
    }

    private void TotalValue()
    {
        if (ListFood is null) return;

        HaveList = ListFood.Count != 0;

        var superFood = FoodService.SumFoodNutrients(new List<FoodModel>(ListFood));
        superFood.Nome = "Total";

        FoodTotal = FoodService.AddUnitMeasureToValues(superFood);
    }
}