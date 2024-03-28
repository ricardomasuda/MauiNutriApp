using CommunityToolkit.Maui.Views;
using NutriApp.AppNutri.Model;

namespace NutriApp.Views.Evaluation.CircumferenceCalf.InfoPopup;

public partial class InfoCircumferenceCalfPopupViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<CircunferenciaPanturrilhaModel> _classificationCalf;
    
    public InfoCircumferenceCalfPopupViewModel()
    {
        Fill();
    }
    
    [RelayCommand]
    private void Close(Popup popup)
    {
        popup.Close();
    }

    private void Fill()
    {
        ClassificationCalf = new ObservableCollection<CircunferenciaPanturrilhaModel>
        {
            new() { Classificacao = "Eutrofica", Valor = "maior igual a 31"},
            new() { Classificacao = "Risco de desnutrição", Valor = " < 31 "},
        };
    }
}