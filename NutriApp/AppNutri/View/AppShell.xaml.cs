using NutriApp.AppNutri.View.About;
using NutriApp.AppNutri.View.Evaluation.AdequacyWeight;
using NutriApp.AppNutri.View.Evaluation.AdjustedWeight;
using NutriApp.AppNutri.View.Evaluation.BodyComposition;
using NutriApp.AppNutri.View.Evaluation.CircumferenceCalf;
using NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;
using NutriApp.AppNutri.View.Evaluation.EstimatedHeight;
using NutriApp.AppNutri.View.Evaluation.IdealWeight;
using NutriApp.AppNutri.View.Evaluation.Imc;
using NutriApp.AppNutri.View.Evaluation.List;
using NutriApp.AppNutri.View.Evaluation.SemiologyNutritional;
using NutriApp.AppNutri.View.Food.Detail;
using NutriApp.AppNutri.View.Food.List;
using NutriApp.AppNutri.View.MainPage;
using NutriApp.AppNutri.View.Suggestion;

namespace NutriApp.AppNutri.View;

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
        Routing.RegisterRoute(nameof(LoaginPage), typeof(LoaginPage));

        Routing.RegisterRoute(nameof(ImcPage), typeof(ImcPage));
        Routing.RegisterRoute(nameof(IdealWeightPage), typeof(IdealWeightPage));
        Routing.RegisterRoute(nameof(AdjustedWeightPage), typeof(AdjustedWeightPage));
        Routing.RegisterRoute(nameof(AdequacyWeightPage), typeof(AdequacyWeightPage));
        Routing.RegisterRoute(nameof(BodyCompositionPage), typeof(BodyCompositionPage));
        Routing.RegisterRoute(nameof(EstimatedHeightPage), typeof(EstimatedHeightPage));
        Routing.RegisterRoute(nameof(CircumferenceWaistPage), typeof(CircumferenceWaistPage));
        Routing.RegisterRoute(nameof(CircumferenceCalfPage), typeof(CircumferenceCalfPage));
        Routing.RegisterRoute(nameof(SemiologiaNutricionalList), typeof(SemiologiaNutricionalList));
        
        Routing.RegisterRoute(nameof(FoodListPage), typeof(FoodListPage));
        Routing.RegisterRoute(nameof(FoodDetailPage), typeof(FoodDetailPage));
        
    }
    
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);

        // try
        // {
        //     if (Current != null && !(args.Target.Location.OriginalString.Contains("LoaginPage")))
        //     {
        //         await Current.Navigation.PushModalAsync(new LoaginPage());
        //     }
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        // }
       
       
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
    
        // if (Current != null && Current.Navigation.ModalStack.LastOrDefault() is LoaginPage)
        // {
        //     Current.Navigation.PopModalAsync();
        // }
    }
}