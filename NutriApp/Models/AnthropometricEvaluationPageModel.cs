namespace NutriApp.Models;

public partial class AnthropometricEvaluationPageModel : ObservableObject
{
    [ObservableProperty] private string _abdominal;
    [ObservableProperty] private string _biceps;
    [ObservableProperty] private string _chest ;
    [ObservableProperty] private string _medialAxilla ;
    [ObservableProperty] private string _middleAxillary ;
    
    
    [ObservableProperty] private string _lateralCalf ;
    [ObservableProperty] private string _triceps ;
    [ObservableProperty] private string _thigh ;
    [ObservableProperty] private string _subScapular ;
    [ObservableProperty] private string _suprailiac ;
    //TODO - verificar calculo
    [ObservableProperty] private string _medialCalf;
}