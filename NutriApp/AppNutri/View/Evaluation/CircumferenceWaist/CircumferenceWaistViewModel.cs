using System.Globalization;
using CommunityToolkit.Maui.Views;
using NutriApp.AppNutri.Componente;
using NutriApp.AppNutri.Model;
using NutriApp.AppNutri.service;
using NutriApp.AppNutri.Utils;

namespace NutriApp.AppNutri.View.Evaluation.CircumferenceWaist;

public class CircumferenceWaistViewModel : BaseViewModel
    {
        private bool _checkedWoman;
        public bool CheckedWoman { get => _checkedWoman;
            set { _checkedWoman = value; OnPropertyChanged("CheckedWoman");
            if (CheckedWoman) CheckedMan = false;
        } }
        
        private bool _checkedMan;
        public bool CheckedMan { get => _checkedMan;
            set { _checkedMan = value; OnPropertyChanged("CheckedMan");
            if (CheckedMan) CheckedWoman = false;
        } }
        
        private bool _hasErrorCircumferenceAbdominal;
        public bool HasErrorCircumferenceAbdominal { get => _hasErrorCircumferenceAbdominal;
            set { _hasErrorCircumferenceAbdominal = value; OnPropertyChanged("HasErrorCircumferenceAbdominal"); } }
        
        private bool _hasErrorCircumferenceHip;
        public bool HasErrorCircumferenceHip { get => _hasErrorCircumferenceHip;
            set { _hasErrorCircumferenceHip = value; OnPropertyChanged("HasErrorCircumferenceHip"); } }
        
        private bool _hasErrorAge;
        public bool HasErrorAge { get => _hasErrorAge;
            set { _hasErrorAge = value; OnPropertyChanged("HasErrorIdade"); } }

        private string _circumferenceHip;
        public string CircumferenceHip { get => _circumferenceHip;
            set { _circumferenceHip = value; OnPropertyChanged("CircumferenceHip"); } }
        
        private string _circumferenceAbdominal;
        public string CircumferenceAbdominal { get { return _circumferenceAbdominal; } set { _circumferenceAbdominal = value; OnPropertyChanged("CircumferenceAbdominal"); } }
        
        private string _age;
        public string Age { get => _age;
            set { _age = value; OnPropertyChanged("Age"); } }
        
        public string Result { get => _result;
            set { _result = value; OnPropertyChanged("Result"); } }

        private string _result;
        
        public bool DisplayResult { get => _displayResult;
            set { _displayResult = value; OnPropertyChanged("DisplayResult"); } }

        private bool _displayResult;
        
        private string _classification;
        public string Classification { get => _classification;
            set { _classification = value; OnPropertyChanged("Classification"); } }

        public Command CalculateCommand { get; set; }
        public Command InfoImcCommand { get; set; }
        public Command WomanCommand { get; set; }
        public Command ManCommand { get; set; }

        public CircumferenceWaistViewModel(CircumferenceWaistPage circumferenceWaistPage)
        {
            CalculateCommand = new Command(Calculate);
            InfoImcCommand = new Command( async () => circumferenceWaistPage.ShowPopup(new InfoCircumferenceWaistPopup()));
            WomanCommand = new Command(() => CheckedWoman = !CheckedWoman);
            ManCommand = new Command(() => CheckedMan = !CheckedMan);
        }

        private void Calculate()
        {
            if (!Validate())
            {
                DisplayResult = false;
                return;
            }
            
            Result = Math.Round(EvaluationCalculations.CircumferenceWaist(Convert.ToDouble(CircumferenceAbdominal), Convert.ToDouble(CircumferenceHip)), 2).ToString(CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(Result))
            {
                DisplayResult = true;
                Classification = WaistCircumferenceService.GetWaistCircumferenceRatio(CommonCalculations.ConverterDouble(Result) , Convert.ToInt32(Age), CheckedMan ? Genders.Male : Genders.Female );
            }
        }
        
        private bool Validate()
        {
            HasErrorCircumferenceAbdominal = string.IsNullOrWhiteSpace(CircumferenceAbdominal);
            HasErrorCircumferenceHip = string.IsNullOrWhiteSpace(CircumferenceHip);
            HasErrorAge = string.IsNullOrWhiteSpace(Age);
            
            if (!(CheckedWoman || CheckedMan))
            {
                //App.NavPage.DisplayToastAsync( "Selecione um gênero");
                return false;
            }
            return (!HasErrorCircumferenceAbdominal && !HasErrorCircumferenceHip );
        }

    }