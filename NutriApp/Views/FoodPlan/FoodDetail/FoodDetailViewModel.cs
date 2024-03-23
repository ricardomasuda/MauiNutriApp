using NutriApp.Views.FoodPlan.MealList;

namespace NutriApp.Views.FoodPlan.FoodDetail;

public class FoodDetailViewModel : BaseViewModel
    {
        private FoodModel _foodTotal;
        public FoodModel FoodTotal { get => _foodTotal; set { _foodTotal = value; OnPropertyChanged(); } }
        
        private ObservableCollection<FoodModel> _listFood;
        public ObservableCollection<FoodModel> ListFood { get => _listFood; set { _listFood = value; OnPropertyChanged(); } }

        private Item _itemMeal;
        public Item ItemMeal { get => _itemMeal; set {_itemMeal = value; OnPropertyChanged(); } }
        
        private ObservableCollection<Item> _listItemMeal;
        public ObservableCollection<Item> ListItemMeal { get => _listItemMeal; set { _listItemMeal = value; OnPropertyChanged(); } }

        private string _title;
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        
        private TypeTitleEnum _titleType;
        public TypeTitleEnum TitleType { get => _titleType; set { _titleType = value; OnPropertyChanged(); } }
        
        private TimeSpan _hour;
        public TimeSpan Hour { get => _hour; set { _hour = value; OnPropertyChanged(); } }
        
        private bool _hasErrorHour;
        public bool HasErrorHour { get => _hasErrorHour; set { _hasErrorHour = value; OnPropertyChanged(); } }
        private bool _canSeeReport;
        public bool CanSeeReport { get => _canSeeReport; set { _canSeeReport = value; OnPropertyChanged(); } }
        
        private bool _hasErrorItemMeal;
        public bool HasErrorItemMeal { get => _hasErrorItemMeal;  set { _hasErrorItemMeal = value; OnPropertyChanged(); } }
        
        private bool _haveList;
        public bool HaveList { get => _haveList; set { _haveList = value; OnPropertyChanged(); } }

        public Command AddOrEditFoodCommand { get; set; }
        public Command EditListFoodCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command GoReportCommand { get; set; }
        public Command RemoveFoodCommand { get; set; }
        public Command DeleteMealCommand { get; set; }

        private readonly MealModel _meal;
        
        private readonly FoodPlanDetailViewModel _foodPlanDetailViewModel;

        public FoodDetailViewModel(FoodPlanDetailViewModel foodPlanDetailViewModel, MealModel meal = null)
        {
            _foodPlanDetailViewModel = foodPlanDetailViewModel;
            _meal = meal;
            AddOrEditFoodCommand = new Command(AddOrEditFood);
            SaveCommand = new Command(SaveFood);
            DeleteMealCommand = new Command(DeleteMeal);
            GoReportCommand = new Command(GoReport);
            EditListFoodCommand = new Command(EditListFood);
            RemoveFoodCommand = new Command(RemoveFoodList);
            Fetch();
        }

        private async void DeleteMeal()
        {
            if (!await Shell.Current.DisplayAlert("Apagar Refeição", "Você deseja apagar refeição", "Sim", "Não"))
                return;
            await new MealDB().ExcluirTotalAsync(_meal.Id);
            
            await Shell.Current.Navigation.PopAsync();
        }

        private void GoReport()
        {
            List<FoodModel> listFood = ListFood.Select(FoodService.RemoveUnitMeasurement).ToList();
            //App.NavPage.PushAsync(new ReportPage(listFood, ItemMeal.Nome));
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
                RemoveFoodList(oldFood);
                SaveFoodList(newFood);
            }
            else if (ListFood.Contains(oldFood))
            {
                var indexFood = ListFood.IndexOf(oldFood);
                RemoveFoodList(oldFood);
                ListFood.Insert(indexFood, newFood);
            }
            TotalValue();
        }

        public async void RemoveFoodList(object obj)
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

        private async void AddOrEditFood(object obj)
        {
            FoodModel food = (FoodModel)obj;
            
            //await App.NavPage.Navigation.PushPopupAsync(new SelectFoodPopup(this,food));
        }

        private async void SaveFood()
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

        private async void EditListFood()
        {
            //await App.NavPage.Navigation.PushPopupAsync(new SelectListFoodPopup(ListFood, this));
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

        private void TotalValue()
        {
            if (ListFood == null) return;

            HaveList = ListFood.Count != 0;

            var superFood = FoodService.SumFoodNutrients(new List<FoodModel>(ListFood));
            superFood.Nome = "Total";

            FoodTotal = FoodService.AddUnitMeasureToValues(superFood);
        }
    }