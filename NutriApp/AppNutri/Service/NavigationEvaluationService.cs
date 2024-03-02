using System.Collections.ObjectModel;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.View.Evaluation.AdequacyWeight;
using NutriApp.AppNutri.View.Evaluation.AdjustedWeight;
using NutriApp.AppNutri.View.Evaluation.BodyComposition;
using NutriApp.AppNutri.View.Evaluation.CircumferenceCalf;
using NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;
using NutriApp.AppNutri.View.Evaluation.EstimatedHeight;
using NutriApp.AppNutri.View.Evaluation.IdealWeight;
using NutriApp.AppNutri.View.Evaluation.Imc;
using NutriApp.AppNutri.View.Evaluation.SemiologyNutritional;
using NutriApp.Resources.Strings;

namespace NutriApp.AppNutri.service;

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
            if (itemMenu.Titulo == EvaluationMenuStrings.Imc)
            {
                await Shell.Current.GoToAsync(nameof(ImcPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.PesoIdeal)
            {
                await Shell.Current.GoToAsync(nameof(IdealWeightPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.PesoAjustado)
            {
                await Shell.Current.GoToAsync(nameof(AdjustedWeightPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.AdequacaoPeso)
            {
                await Shell.Current.GoToAsync(nameof(AdequacyWeightPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.ComposicaoCorporal)
            {
                await Shell.Current.GoToAsync(nameof(BodyCompositionPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.AlturaEstimada)
            {
                await Shell.Current.GoToAsync(nameof(EstimatedHeightPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaCintura)
            {
                await Shell.Current.GoToAsync(nameof(CircumferenceWaistPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaPanturrilha)
            {
                await Shell.Current.GoToAsync(nameof(CircumferenceCalfPage));
                return;
            }
            if (itemMenu.Titulo == EvaluationMenuStrings.SemiologiaNutricional)
            {
                await Shell.Current.GoToAsync(nameof(SemiologiaNutricionalList));
                return;
            }
            //if (itemMenu.Titulo == EvaluationMenuStrings.PesoEstimado)  { await Navigation.PushPageAsync(new EstimatedWeightPage()); return;}
            //if (itemMenu.Titulo == EvaluationMenuStrings.ValorReference) { await Navigation.PushPageAsync(new ReferenceValuePage()); return;}
            await Shell.Current.DisplayAlert("Em Construção", "Em construção", "OK");
        }
}