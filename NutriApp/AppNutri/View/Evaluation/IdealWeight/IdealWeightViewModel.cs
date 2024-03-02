using System.Collections.ObjectModel;
using System.Globalization;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.Utils;
using NutriApp.AppNutri.View.Evaluation.IdealWeight.InfoPopup;
using CommunityToolkit.Maui.Views;

namespace NutriApp.AppNutri.View.Evaluation.IdealWeight;

public class IdealWeightViewModel : BaseViewModel
{
      private bool _canDisplay;
        public bool CanDisplay { get => _canDisplay; set { _canDisplay = value; OnPropertyChanged("CanDisplay"); } }
        
        private Item _imcIdeal;
        public Item ImcIdeal { get => _imcIdeal; set { _imcIdeal = value; OnPropertyChanged("ImcIdeal"); } }
        
        private string _height;
        public string Height { get => _height; set { _height = value; OnPropertyChanged("Height"); } }
        
        private string _idealWeight;
        public string IdealWeight { get => _idealWeight; set { _idealWeight = value; OnPropertyChanged("IdealWeight"); } }
        
        private bool _hasErrorHeight;
        public bool HasErrorHeight { get => _hasErrorHeight; set { _hasErrorHeight = value; OnPropertyChanged("HasErrorHeight"); } }
        
        private bool _hasErrorImcIdeal;
        public bool HasErrorImcIdeal { get => _hasErrorImcIdeal; set { _hasErrorImcIdeal = value; OnPropertyChanged("HasErrorImcIdeal"); } }
        
        public ObservableCollection<Item> ItemImcIdeal { get; set; } 
        public Command CalculateCommand { get; set; }
        public Command InfoCommand { get; set; }
        public IdealWeightViewModel(IdealWeightPage page)
        {
            CalculateCommand = new Command(Calculate);
            InfoCommand = new Command(() => page.ShowPopup(new InfoIdealWeightPopup()));
            CanDisplay = false;
            Fill();
        }

        private void Fill()
        {
            ItemImcIdeal =  new ObservableCollection<Item>
            {
                new() {Id = 22, Nome = "Homem 22 kg/m²"},
                new() {Id = 21, Nome = "Mulher 21 kg/m²"}
            };
        }
        
        private async void GotoInfo()
        {
            //await Navigation.PushPopupAsync(new InfoIdealWeightPopup());
        }

        private void Calculate()
        {
            if (!Validate())
            {
                CanDisplay = false;
                return;
            }

            var teste = Convert.ToDouble(ImcIdeal.Id);
            var teste1 = Utils.Utils.ConvertHeight(Height);
            IdealWeight = EvaluationCalculations.IdealWeight(Convert.ToDouble(ImcIdeal.Id), Utils.Utils.ConvertHeight(Height)).ToString(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(IdealWeight))
            {
                CanDisplay = true;
            }
        }
        private bool Validate()
        {
            HasErrorHeight = string.IsNullOrWhiteSpace(Height);
            HasErrorImcIdeal = ImcIdeal == null;

            return (!HasErrorHeight && !HasErrorImcIdeal);
        }
}