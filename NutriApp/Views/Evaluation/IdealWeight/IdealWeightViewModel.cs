using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Maui.Views;
using MvvmHelpers;
using NutriApp.AppNutri.View.Evaluation.IdealWeight.InfoPopup;
using NutriApp.Models;
using NutriApp.Utils;

namespace NutriApp.Views.Evaluation.IdealWeight;

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
        public IdealWeightViewModel()
        {
            CalculateCommand = new Command(Calculate);
            InfoCommand = new Command(() => Shell.Current.CurrentPage.ShowPopup(new InfoIdealWeightPopup()));
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