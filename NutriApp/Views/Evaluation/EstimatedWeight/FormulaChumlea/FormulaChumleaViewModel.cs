using System.Windows.Input;
using CommunityToolkit.Maui.Core;

namespace NutriApp.Views.Evaluation.EstimatedWeight.FormulaChumlea;

public partial class FormulaChumleaViewModel : BaseViewModel
{
        private bool _checkedWoman;
        public bool CheckedWoman
        {
            get => _checkedWoman;
            set
            {
                _checkedWoman = value;
                OnPropertyChanged("CheckedWoman");
                if (CheckedWoman) CheckedMan = false;
            }
        }

        private bool _checkedMan;
        public bool CheckedMan
        {
            get => _checkedMan;
            set
            {
                _checkedMan = value;
                OnPropertyChanged("CheckedMan");
                if (CheckedMan) CheckedWoman = false;
            }
        }
        [ObservableProperty]
        private string _circunferenciaPerna;

        [ObservableProperty]
        private string _alturaJoelho;
        [ObservableProperty]
        private string _brachialMuscleCircumference;

        [ObservableProperty]
        private string _subscapularSkinfold;

        [ObservableProperty]
        private bool _hasErrorCircunferenciaPerna;

        [ObservableProperty]
        private bool _hasErrorAlturaJoelho;

        [ObservableProperty]
        private bool _hasErrorBrachialMuscleCircumference;

        [ObservableProperty]
        private bool _hasErrorSubscapularSkinfold;

        public ICommand CheckWomanCommand => new RelayCommand(() => CheckedWoman = !CheckedWoman);
        public ICommand CheckManCommand => new RelayCommand(() => CheckedMan = !CheckedMan);

        public FormulaChumleaViewModel()
        {
        }
        
        public bool ValidateData()
        {
            HasErrorCircunferenciaPerna = string.IsNullOrWhiteSpace(CircunferenciaPerna);
            HasErrorAlturaJoelho = string.IsNullOrWhiteSpace(AlturaJoelho);
            HasErrorBrachialMuscleCircumference = string.IsNullOrWhiteSpace(BrachialMuscleCircumference);
            HasErrorSubscapularSkinfold = string.IsNullOrWhiteSpace(SubscapularSkinfold);
                
            if (!(CheckedWoman || CheckedMan))
            {
                InfoToaster( "Selecione um gênero", ToastDuration.Long);
                return false;
            }
            return (!HasErrorCircunferenciaPerna && !HasErrorAlturaJoelho && !HasErrorBrachialMuscleCircumference && !HasErrorSubscapularSkinfold);
        }
}