using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.CircumferenceWaist.InfoPopup;

public partial class InfoCircumferenceWaistPopupViewModel : BaseViewModel
{
    [ObservableProperty] 
    private ObservableCollection<CircunferenciaCintura> _classificationMan;
    [ObservableProperty] 
    private ObservableCollection<CircunferenciaCintura> _classificationWoman;

    public InfoCircumferenceWaistPopupViewModel(InfoCircumferenceWaistPopup infoCircumferenceWaistPopup)
    {
        FillData();
    }
    
    [RelayCommand]
    private void Close(Popup popup)
    {
        popup.Close();
    }
    
    private void FillData()
    {
        ClassificationWoman = new ObservableCollection<CircunferenciaCintura>
        {
            new() {Idade = "20 a 29 anos", Baixo = "<0.71", Moderado = "0.71 a 0.77", Alto = "0.78 a 0.82" ,MuitoAlto = ">0.82"},
            new() {Idade = "30 a 39 anos", Baixo = "<0.71", Moderado = "0.72 a 0.78", Alto = "0.79 a 0.84" ,MuitoAlto = ">0.84"},
            new() {Idade = "40 a 49 anos", Baixo = "<0.73", Moderado = "0.73 a 0.79", Alto = "0.80 a 0.87" ,MuitoAlto = ">0.87"},
            new() {Idade = "50 a 59 anos", Baixo = "<0.74", Moderado = "0.74 a 0.81", Alto = "0.82 a 0.88" ,MuitoAlto = ">0.88"},
            new() {Idade = "60 a 69 anos", Baixo = "<0.76", Moderado = "0.76 a 0.83", Alto = "0.84 a 0.90" ,MuitoAlto = ">0.90"},
        };
        
        ClassificationMan = new ObservableCollection<CircunferenciaCintura>
        {
            new() {Idade = "20 a 29 anos", Baixo = "<0.83", Moderado = "0.83 a 0.88", Alto = "0.89 a 0.94" ,MuitoAlto = ">0.94"},
            new() {Idade = "30 a 39 anos", Baixo = "<0.84", Moderado = "0.84 a 0.91", Alto = "0.92 a 0.96" ,MuitoAlto = ">0.96"},
            new() {Idade = "40 a 49 anos", Baixo = "<0.88", Moderado = "0.88 a 0.95", Alto = "0.96 a 1.00" ,MuitoAlto = ">1.00"},
            new() {Idade = "50 a 59 anos", Baixo = "<0.90", Moderado = "0.90 a 0.96", Alto = "0.97 a 1.02" ,MuitoAlto = ">1.02"},
            new() {Idade = "60 a 69 anos", Baixo = "<0.91", Moderado = "0.91 a 0.98", Alto = "0.99 a 1.03" ,MuitoAlto = ">1.03"},
        };
    }
}

