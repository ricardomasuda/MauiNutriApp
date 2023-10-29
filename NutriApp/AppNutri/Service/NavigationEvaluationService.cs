using System.Collections.ObjectModel;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.View.Evaluation.Imc;
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
            if (itemMenu.Titulo == EvaluationMenuStrings.Imc) { await Navigation.PushPageAsync(new ImcPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.PesoIdeal) { await Navigation.PushPageAsync(new IdealWeightPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.PesoAjustado) { await Navigation.PushPageAsync(new AdjustedWeightPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.AdequacaoPeso) { await Navigation.PushPageAsync(new AdequacyWeightPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.ComposicaoCorporal) { await Navigation.PushPageAsync(new BodyCompositionPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.PesoEstimado)  { await Navigation.PushPageAsync(new EstimatedWeightPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.AlturaEstimada) { await Navigation.PushPageAsync(new EstimatedHeightPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaCintura) { await Navigation.PushPageAsync(new CircumferenceWaistPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.CircunferenciaPanturrilha) { await Navigation.PushPageAsync(new CircumferenceCalfPage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.ValorReference) { await Navigation.PushPageAsync(new ReferenceValuePage()); return;}
            // if (itemMenu.Titulo == EvaluationMenuStrings.SemiologiaNutricional) { await Navigation.PushPageAsync(new SemiologiaNutricionalList()); return;}
            await App.NavPage.DisplayAlert("Em Construção", "Em construção", "OK");
            
        }
}