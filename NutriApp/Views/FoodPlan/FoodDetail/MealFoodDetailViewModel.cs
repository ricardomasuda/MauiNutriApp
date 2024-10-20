using NutriApp.Views.FoodPlan.FoodDetail.SelectList;
using NutriApp.Views.FoodPlan.MealList;
using NutriApp.Views.FoodPlan.SelectFood.SelectFoodPopup;

namespace NutriApp.Views.FoodPlan.FoodDetail;

[QueryProperty(nameof(MealModel), nameof(MealModel))]
[QueryProperty(nameof(FoodPlanDetailPageViewModel), nameof(FoodPlanDetailPageViewModel))]
public partial class MealFoodDetailViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty] private FoodModel _foodTotal;
    [ObservableProperty] private ObservableCollection<FoodModel> _listFood;
    [ObservableProperty] private Item _selectedItemMeal;
    [ObservableProperty] private ObservableCollection<Item> _listItemMeal;
    [ObservableProperty] private string _title;
    [ObservableProperty] private TypeTitleEnum _titleType;
    [ObservableProperty] private TimeSpan _hour;
    [ObservableProperty] private bool _hasErrorHour;
    [ObservableProperty] private bool _canSeeReport;
    [ObservableProperty] private bool _hasErrorItemMeal;
    [ObservableProperty] private bool _haveList;
    [ObservableProperty] private double _collectionViewHeight;
    [ObservableProperty] private double _footerWidth;

    private MealModel _meal;
    private FoodPlanDetailPageViewModel _foodPlanDetailPageViewModel;
    private MealFoodDetailPage _mealFoodDetailPage;

    public MealFoodDetailViewModel(MealFoodDetailPage mealFoodDetailPage)
    {
        Fetch();
        _mealFoodDetailPage = mealFoodDetailPage;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _foodPlanDetailPageViewModel = query[nameof(FoodPlanDetailPageViewModel)] as FoodPlanDetailPageViewModel;
        _meal = GetQueryValue<MealModel>(query, nameof(MealModel));
        Fetch();
    }
    
    private async void Fetch()
    {
        FoodTotal = new FoodModel();
        ListItemMeal = new MealModel().MealType();
        ListFood = new ObservableCollection<FoodModel>();
        if (_meal != null)
        {
            Title = "Atualizar Refeição";
            TitleType = TypeTitleEnum.Trash;
            Hour = TimeSpan.Parse(_meal.Horario);
            ListFood = await DataBaseService.GetFoodWhere(_meal.Id);
            HaveList = ListFood.Count != 0;
            _mealFoodDetailPage.OnItemSelected(_meal.Nome);
            CanSeeReport = HaveList;
            CalculateHeightList();
        }
        else
        {
            Title = "Salvar Refeição";
            CanSeeReport = false;
            TitleType = TypeTitleEnum.None;
        }

        FooterWidth = (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density) - 55;

        TotalValue();
        FoodService.AddUnitMeasureList(ListFood);
    }

    public void SaveFoodList(FoodModel food)
    {
        ListFood.Add(FoodService.AddUnitMeasureToValues(food));
        TotalValue();
        CalculateHeightList();
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
    private async void GoReport()
    {
        List<FoodModel> listFood = ListFood.Select(FoodService.RemoveUnitMeasurement).ToList();
        ShellNavigationQueryParameters navigationParameter = new() {
            { "FoodList", listFood },
            { "Title", SelectedItemMeal.Nome}
        };
        await App.NavPage.GoToAsync(nameof(ReportPage), navigationParameter);
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

        await App.NavPage.GoToModalAsync(new SelectFoodPopup(this, food));
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
            Nome = SelectedItemMeal.Nome,
            FoodPLanId = _foodPlanDetailPageViewModel.FoodPlanModel.Id,
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

    private void CalculateHeightList()
    {
        CollectionViewHeight = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density) * 0.4;
    }

    private void RemoveFoodTotal()
    {
        var foodModel = ListFood.FirstOrDefault(x => x.Nome == "Total:");
        ListFood.Remove(foodModel);
    }

    private bool Validate()
    {
        HasErrorHour = string.IsNullOrWhiteSpace(Hour.ToString());
        HasErrorItemMeal = SelectedItemMeal == null;

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