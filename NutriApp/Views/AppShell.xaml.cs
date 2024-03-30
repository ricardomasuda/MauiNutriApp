using NutriApp.Views.About;
using NutriApp.Views.Evaluation.AdequacyWeight;
using NutriApp.Views.Evaluation.AdjustedWeight;
using NutriApp.Views.Evaluation.BodyComposition;
using NutriApp.Views.Evaluation.CircumferenceCalf;
using NutriApp.Views.Evaluation.CircumferenceWaist;
using NutriApp.Views.Evaluation.EstimatedHeight;
using NutriApp.Views.Evaluation.EstimatedWeight;
using NutriApp.Views.Evaluation.IdealWeight;
using NutriApp.Views.Evaluation.Imc;
using NutriApp.Views.Evaluation.List;
using NutriApp.Views.Evaluation.SemiologyNutritional;
using NutriApp.Views.Food.Detail;
using NutriApp.Views.Food.List;
using NutriApp.Views.FoodPlan.FoodPlanList;
using NutriApp.Views.Suggestion;

namespace NutriApp.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //Não pode colocar a main
        //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage.MainPage));
        Routing.RegisterRoute(nameof(EvaluationListPage), typeof(EvaluationListPage));
       
        Routing.RegisterRoute(nameof(SuggestionPage), typeof(SuggestionPage));
        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));

        Routing.RegisterRoute(nameof(ImcPage), typeof(ImcPage));
        Routing.RegisterRoute(nameof(IdealWeightPage), typeof(IdealWeightPage));
        Routing.RegisterRoute(nameof(AdjustedWeightPage), typeof(AdjustedWeightPage));
        Routing.RegisterRoute(nameof(AdequacyWeightPage), typeof(AdequacyWeightPage));
        Routing.RegisterRoute(nameof(BodyCompositionPage), typeof(BodyCompositionPage));
        Routing.RegisterRoute(nameof(EstimatedHeightPage), typeof(EstimatedHeightPage));
        Routing.RegisterRoute(nameof(CircumferenceWaistPage), typeof(CircumferenceWaistPage));
        Routing.RegisterRoute(nameof(CircumferenceCalfPage), typeof(CircumferenceCalfPage));
        Routing.RegisterRoute(nameof(SemiologiaNutricionalListPage), typeof(SemiologiaNutricionalListPage));
        Routing.RegisterRoute(nameof(EstimatedWeightPage), typeof(EstimatedWeightPage));
        
        Routing.RegisterRoute(nameof(FoodListPage), typeof(FoodListPage));
        Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
        
        Routing.RegisterRoute(nameof(FoodPlanListPage), typeof(FoodPlanListPage));
        
    }
    
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
    }
}