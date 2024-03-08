using System.Collections.ObjectModel;
using NutriApp.Components;
using NutriApp.Models;
using NutriApp.Services.AnthropometricEvaluation;

namespace NutriApp.Views.Evaluation.BodyComposition;

public class BodyCompositionPageViewModel : BaseViewModel
{
    private string _height;
    public string Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged("Height");
        }
    }

    private string _wrist;
    public string Wrist
    {
        get => _wrist;
        set
        {
            _wrist = value;
            OnPropertyChanged("Wrist");
        }
    }

    private string _femur;
    public string Femur
    {
        get => _femur;
        set
        {
            _femur = value;
            OnPropertyChanged("Femur");
        }
    }

    private string _weight;
    public string Weight
    {
        get => _weight;
        set
        {
            _weight = value;
            OnPropertyChanged("Weight");
        }
    }

    private bool _hasErrorHeight;
    public bool HasErrorHeight
    {
        get => _hasErrorHeight;
        set
        {
            _hasErrorHeight = value;
            OnPropertyChanged("HasErrorHeight");
        }
    }

    private bool _hasErrorWrist;
    public bool HasErrorWrist
    {
        get => _hasErrorWrist;
        set
        {
            _hasErrorWrist = value;
            OnPropertyChanged("HasErrorWrist");
        }
    }

    private bool _hasErrorFemur;
    public bool HasErrorFemur
    {
        get => _hasErrorFemur;
        set
        {
            _hasErrorFemur = value;
            OnPropertyChanged("HasErrorFemur");
        }
    }

    private bool _hasErrorWeight;
    public bool HasErrorWeight
    {
        get => _hasErrorWeight;
        set
        {
            _hasErrorWeight = value;
            OnPropertyChanged("HasErrorWeight");
        }
    }

    private bool _hasErrorGender;
    public bool HasErrorGender
    {
        get => _hasErrorGender;
        set
        {
            _hasErrorGender = value;
            OnPropertyChanged("HasErrorGender");
        }
    }

    private double _boneMassResult;
    public double BoneMassResult
    {
        get => _boneMassResult;
        set
        {
            _boneMassResult = value;
            OnPropertyChanged("BoneMassResult");
        }
    }

    private double _residualWeightResult;
    public double ResidualWeightResult
    {
        get => _residualWeightResult;
        set
        {
            _residualWeightResult = value;
            OnPropertyChanged("ResidualWeightResult");
        }
    }

    private Item _genderType;
    public Item GenderType
    {
        get => _genderType;
        set
        {
            _genderType = value;
            OnPropertyChanged("GenderType");
        }
    }

    private bool _canDisplayResult;
    public bool CanDisplayResult
    {
        get => _canDisplayResult;
        set
        {
            _canDisplayResult = value;
            OnPropertyChanged("CanDisplayResult");
        }
    }

    public ObservableCollection<Item> ListGender { get; set; }
    public Command CalculateCommand { get; set; }

    public BodyCompositionPageViewModel()
    {
        CalculateCommand = new Command(Calculate);
        ListGender = new ObservableCollection<Item>
        {
            new() { Id = 0, Nome = "Homem" },
            new() { Id = 1, Nome = "Mulher" }
        };
    }

    private void Calculate()
    {
        if (ValidateData())
        {
            BoneMassResult = BodyCompositionService.CalculateBoneMass(Convert.ToDouble(Height), Convert.ToDouble(Wrist),
                Convert.ToDouble(Femur));
            ResidualWeightResult = BodyCompositionService.CalculateResidualWeight(Convert.ToDouble(Weight),
                GenderUtils.ConverterGender(GenderType.Nome));
            CanDisplayResult = true;
        }
    }

    private bool ValidateData()
    {
        HasErrorHeight = string.IsNullOrWhiteSpace(Height);
        HasErrorWrist = string.IsNullOrWhiteSpace(Wrist);
        HasErrorFemur = string.IsNullOrWhiteSpace(Femur);
        HasErrorWeight = string.IsNullOrWhiteSpace(Weight);
        HasErrorGender = string.IsNullOrWhiteSpace(GenderType?.Nome);
        return (!HasErrorHeight && !HasErrorHeight && !HasErrorFemur && !HasErrorWeight && !HasErrorGender);
    }
}