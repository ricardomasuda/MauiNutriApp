
using CommunityToolkit.Maui.Views;
using NutriApp.AppNutri.Model;

namespace NutriApp.Views.Evaluation.CircumferenceCalf.InfoPopup;

public class InfoCircumferenceCalfPopupViewModel : BaseViewModel
{
    private ObservableCollection<CircunferenciaPanturrilhaModel> _classificationCalf;
    public ObservableCollection<CircunferenciaPanturrilhaModel> ClassificationCalf
    {
        get => _classificationCalf;
        set { _classificationCalf = value; OnPropertyChanged("ClassificationCalf"); }
    }
        
    public Command CloseCommand { get; set; }
    public InfoCircumferenceCalfPopupViewModel()
    {
        CloseCommand = new Command<Popup>(ClosePage);
        Fill();
    }
    
    private void ClosePage(Popup popup)
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