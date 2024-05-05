using MauiLib1.Navigation;
using NutriApp.Views.About;
using NutriApp.Views.AnthropometricEvaluation;
using NutriApp.Views.Evaluation.List;
using NutriApp.Views.Food.List;
using NutriApp.Views.FoodPlan.FoodPlanList;
using NutriApp.Views.Suggestion;

namespace NutriApp.Views.MainPage;

public class MainPageViewModel : BaseViewModel
{
    private string _version;
    public string Version { get => _version; set { _version = value; OnPropertyChanged(); } }
    public Command EvaluationCommand { get; set; } =  new ( () =>  App.NavPage.GoToAsync(nameof(EvaluationListPage)));
    public Command ListFoodCommand { get; set; } = new ( () => App.NavPage.GoToAsync(nameof(FoodListPage)));
    public Command SuggestionCommand { get; set; } = new( () => App.NavPage.GoToAsync(nameof(SuggestionPage)));
    public Command AboutAppCommand { get; set; } = new( () => App.NavPage.GoToAsync(nameof(AboutPage)));
    public Command FoodPlanCommand { get; set; } =  new ( () => App.NavPage.GoToAsync(nameof(FoodPlanListPage)));
    public Command AnthropometricEvaluationCommand { get; set; } =  new ( () => App.NavPage.GoToAsync(nameof(AnthropometricEvaluationPage)));
    // AnthropometricEvaluationCommand = new Command( () => Navigation.PushPageAsync(new AnthropometricEvaluationPage()));
 
    public MainPageViewModel() 
    {
        App.NavPage = Application.Current.MainPage.Handler.MauiContext.Services.GetService<INavigationService>();
    }
}