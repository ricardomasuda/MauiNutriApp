using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using MvvmHelpers;
using NutriApp.Models;

namespace NutriApp.Views.Evaluation.CircumferenceWaist.InfoPopup;

public class InfoCircumferenceWaistPopupViewModel : BaseViewModel
{
    private ObservableCollection<CircunferenciaCintura> _classificationMan;
    public ObservableCollection<CircunferenciaCintura> ClassificationMan
    {
        get => _classificationMan;
        set { _classificationMan = value; OnPropertyChanged("ClassificationMan"); }
    }

    private ObservableCollection<CircunferenciaCintura> _classificationWoman;
    public ObservableCollection<CircunferenciaCintura> ClassificationWoman
    {
        get => _classificationWoman;
        set { _classificationWoman = value; OnPropertyChanged("ClassificationWoman"); }
    }
    
    private Size _size;
    public Size Size
    {
        get => _size;
        set { _size = value; OnPropertyChanged("Size"); }
    }
    
    public double Height { get; set; }
    public double Width { get; set; }

    private InfoCircumferenceWaistPopup _infoCircumferenceWaistPopup;
    public Command CloseCommand { get; set; }
    public Popup Popup { get; set; }

    public InfoCircumferenceWaistPopupViewModel(InfoCircumferenceWaistPopup infoCircumferenceWaistPopup)
    {
        CloseCommand = new Command<Popup>(ClosePage);
        _infoCircumferenceWaistPopup = infoCircumferenceWaistPopup;
        FillData();
    }
    
    private void ClosePage(Popup popup)
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

