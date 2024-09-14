using NutriApp.Resources.Strings;
using NutriApp.Views.Evaluation.AdequacyWeight;
using NutriApp.Views.Evaluation.AdjustedWeight;
using NutriApp.Views.Evaluation.BodyComposition;
using NutriApp.Views.Evaluation.CircumferenceCalf;
using NutriApp.Views.Evaluation.CircumferenceWaist;
using NutriApp.Views.Evaluation.EstimatedHeight;
using NutriApp.Views.Evaluation.EstimatedWeight;
using NutriApp.Views.Evaluation.IdealWeight;
using NutriApp.Views.Evaluation.Imc;
using NutriApp.Views.Evaluation.ReferenceValue;
using NutriApp.Views.Evaluation.SemiologyNutritional;

namespace NutriApp.Services;

public class NavigationEvaluationService
{
     public static ObservableCollection<ItemMenu> Fetch()
        {
            ObservableCollection<ItemMenu> itemsMenus = new ObservableCollection<ItemMenu>
            {
                new() {Titulo = EvaluationMenuStrings.Imc},
                new() {Titulo = EvaluationMenuStrings.PesoIdeal},
                new() {Titulo = EvaluationMenuStrings.PesoAjustado},
                new() {Titulo = EvaluationMenuStrings.AdequacaoPeso},
                new() {Titulo = EvaluationMenuStrings.PesoEstimado},
                new() {Titulo = EvaluationMenuStrings.ComposicaoCorporal},
                new() {Titulo = EvaluationMenuStrings.AlturaEstimada},
                new() {Titulo = EvaluationMenuStrings.CircunferenciaCintura},
                new() {Titulo = EvaluationMenuStrings.CircunferenciaPanturrilha},
                new() {Titulo = EvaluationMenuStrings.ValorReference},
                new() {Titulo = EvaluationMenuStrings.SemiologiaNutricional}
            };
            return itemsMenus;
        }
        
        public static async void GoEvaluationMenu(ItemMenu itemMenu)
        {
            if (itemMenu.Titulo == EvaluationMenuStrings.Imc) { await App.NavPage.GoToAsync(nameof(ImcPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.PesoIdeal) { await App.NavPage.GoToAsync(nameof(IdealWeightPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.PesoAjustado) { await App.NavPage.GoToAsync(nameof(AdjustedWeightPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.AdequacaoPeso) { await App.NavPage.GoToAsync(nameof(AdequacyWeightPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.ComposicaoCorporal) { await App.NavPage.GoToAsync(nameof(BodyCompositionPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.AlturaEstimada) { await App.NavPage.GoToAsync(nameof(EstimatedHeightPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaCintura) { await App.NavPage.GoToAsync(nameof(CircumferenceWaistPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaPanturrilha) { await App.NavPage.GoToAsync(nameof(CircumferenceCalfPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.SemiologiaNutricional) { await App.NavPage.GoToAsync(nameof(SemiologiaNutricionalListPage)); return; }
            if (itemMenu.Titulo == EvaluationMenuStrings.PesoEstimado)  { await App.NavPage.GoToAsync( nameof(EstimatedWeightPage)); return;}
            if (itemMenu.Titulo == EvaluationMenuStrings.ValorReference) { await App.NavPage.GoToAsync(nameof(ReferenceValuePage)); return;}
            await Shell.Current.DisplayAlert("Em Construção", "Em construção", "OK");
        }
}