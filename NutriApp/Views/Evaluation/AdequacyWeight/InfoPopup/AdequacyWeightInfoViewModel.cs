using CommunityToolkit.Maui.Views;

namespace NutriApp.Views.Evaluation.AdequacyWeight.InfoPopup;

public partial class AdequacyWeightInfoViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<AdequacaoPeso> _adequacaoPesos;
    public AdequacyWeightInfoViewModel()
    {
        FillData();
    }
    
    [RelayCommand]
    private void Close(Popup popup)
    {
        popup.Close();
    }

    private void FillData() {
        AdequacaoPesos = new ObservableCollection<AdequacaoPeso> {
            new() { ValorEncontrado = "> 120.0", Classificacao = "Obesidade" },
            new() { ValorEncontrado = "110.1 a 120.0", Classificacao = "Sobrepeso" },
            new() { ValorEncontrado = "90.1 a 110.0", Classificacao = "Eutrofia" },
            new() { ValorEncontrado = "80.1 a 90.0", Classificacao = "Desnutrição leve" },
            new() { ValorEncontrado = "70.1 a 80.0", Classificacao = "Desnutrição moderada" },
            new() { ValorEncontrado = "<= 70.0", Classificacao = "Desnutrição grave" },
        };
    }
}