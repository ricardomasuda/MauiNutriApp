using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.View.About;
using NutriApp.AppNutri.View.Evaluation.List;
using NutriApp.AppNutri.View.Food.List;
using NutriApp.AppNutri.View.Suggestion;

namespace NutriApp.AppNutri.View.MainPage;

public class MainPageViewModel : BaseViewModel
{
    private string _version;
    public string Version { get => _version; set { _version = value; OnPropertyChanged("Version"); } }
    public Command EvaluationCommand { get; set; } = new(async () => await Navigation.Navigation.PushPageAsync(new EvaluationListPage()));
    public Command AnthropometricEvaluationCommand { get; set; }
    public Command ListFoodCommand { get; set; } = new ( async() => await Navigation.Navigation.PushPageAsync(new FoodListPage()));
    public Command FoodPlanCommand { get; set; }
    public Command SuggestionCommand { get; set; } = new(async () => await Navigation.PushPageAsync(new SuggestionPage()));
    public Command AboutAppCommand { get; set; } = new(async () => await Navigation.PushPageAsync(new AboutPage()));
    // FoodPlanCommand = new Command( () => Navigation.PushPageAsync(new FoodPlanList()));
    // AnthropometricEvaluationCommand = new Command( () => Navigation.PushPageAsync(new AnthropometricEvaluationPage()));
    //FillPage();

    // private void FillPage()
    // {
    //     Version = App.Version;
    // }
}