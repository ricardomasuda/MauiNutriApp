using NutriApp.AppNutri.View.Evaluation;
using NutriApp.AppNutri.View.Evaluation.List;
using NutriApp.Componente;

namespace NutriApp.AppNutri.View.MainPage;

public class MainPageViewModel : BaseViewModel
{
    private string _version;
    public string Version { get => _version; set { _version = value; OnPropertyChanged("Version"); } }
    public Command EvaluationCommand { get; set; } = new(async () => await Navigation.PushPageAsync(new EvaluationListPage()));
    public Command AnthropometricEvaluationCommand { get; set; }
    public Command ListFoodCommand { get; set; }
    public Command FoodPlanCommand { get; set; }
    public Command SuggestionCommand { get; set; }
    public Command AboutAppCommand { get; set; }

    // ListFoodCommand = new Command(() => Navigation.PushPageAsync(new FoodList()));
    // AboutAppCommand = new Command(() => Navigation.PushPageAsync(new AboutPage()));
    // SuggestionCommand = new Command(() => Navigation.PushPageAsync(new SuggestionPage()));
    // FoodPlanCommand = new Command( () => Navigation.PushPageAsync(new FoodPlanList()));
    // AnthropometricEvaluationCommand = new Command( () => Navigation.PushPageAsync(new AnthropometricEvaluationPage()));
    //FillPage();

    // private void FillPage()
    // {
    //     Version = App.Version;
    // }
}