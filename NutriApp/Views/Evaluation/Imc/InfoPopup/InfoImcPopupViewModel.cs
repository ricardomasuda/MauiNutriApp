using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using MvvmHelpers;
using NutriApp.Models;

namespace NutriApp.Views.Evaluation.Imc.InfoPopup;

public class InfoImcPopupViewModel : BaseViewModel
{
     private ObservableCollection<ImcClassificacao> _imcAdultClassification;
        public ObservableCollection<ImcClassificacao> ImcAdultClassification
        {
            get => _imcAdultClassification;
            set
            {
                _imcAdultClassification = value;
                OnPropertyChanged("ImcAdultClassification");
            }
        }

        private ObservableCollection<ImcClassificacao> _imcSeniorClassification;
        public ObservableCollection<ImcClassificacao> ImcSeniorClassification
        {
            get => _imcSeniorClassification;
            set
            {
                _imcSeniorClassification = value;
                OnPropertyChanged("ImcSeniorClassification");
            }
        }
        
        public Popup Popup { get; set; }
        public Command CloseCommand { get; set; }

        public InfoImcPopupViewModel()
        {
            FillData();
            CloseCommand = new Command<Popup>(ClosePage);
        }

        private void ClosePage(Popup popup)
        {
            popup.Close();
        }

        private void FillData()
        {
            ImcAdultClassification = new ObservableCollection<ImcClassificacao>
            {
                new() {Classificacao = "Magreza grau III", Imc = " menor que 16,0"},
                new() {Classificacao = "Magreza grau II", Imc = " 16,1 - 16,99"},
                new() {Classificacao = "Magreza grau I", Imc = "17,0 - 18,49"},
                new() {Classificacao = "Normal (eutrófico)", Imc = "18,5 - 24,99"},
                new() {Classificacao = "Sobrepeso", Imc = "25,0 - 29,99"},
                new() {Classificacao = "Obesidade I", Imc = "30,0 - 34,99"},
                new() {Classificacao = "Obesidade II", Imc = "35,0 - 39,99"},
                new() {Classificacao = "Obesidade III", Imc = " maior igual a 40,0"}
            };
            ImcSeniorClassification = new ObservableCollection<ImcClassificacao>
            {
                new () {Classificacao = "Abaixo do peso", Imc = "menor igual a 22,0"},
                new () {Classificacao = "Adequado ou eutrófico", Imc = "26,99 - 22,1"},
                new () {Classificacao = "Sobrepeso", Imc = "maior igual a 27,0"},
            };
        }
}