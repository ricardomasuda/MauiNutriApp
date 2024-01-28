using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NutriApp.AppNutri.Componente;

public partial class BaseViewModel : INotifyPropertyChanged
{
    // protected void ErrorToaster(string message = "Error!", int durationInSeconds = 3, bool showInBottom = false)
    // {
    //     UserDialogs.Instance.HideLoading();
    //     _feedBackService.Toaster(message, durationInSeconds, showInBottom, EnumToasterType.Error);            
    // }
    //
    // protected void WarningToaster(string message = "Atenção!", int durationInSeconds = 3, bool showInBottom = false)
    // {
    //     UserDialogs.Instance.HideLoading();
    //     _feedBackService.Toaster(message, durationInSeconds, showInBottom, EnumToasterType.Warning);
    // }
    //
    // protected void InfoToaster(string message, int durationInSeconds = 3, bool showInBottom = false)
    // {
    //     UserDialogs.Instance.HideLoading();
    //     _feedBackService.Toaster(message, durationInSeconds, showInBottom, EnumToasterType.Info);
    // }
    //
    // protected void SuccessToaster(string message = "Successo!", int durationInSeconds = 3, bool showInBottom = false)
    // {
    //     UserDialogs.Instance.HideLoading();
    //     ToasterView.Toaster(message, durationInSeconds, showInBottom, EnumToasterType.Success);
    // }
    //     
    // public void ShowLoading(string text = "Carregando", MaskType type = MaskType.Black)
    // {   
    //     UserDialogs.Instance.HideLoading();
    //     UserDialogs.Instance.ShowLoading(text, type);         
    // }
    //     
    // public void HideLoading()
    // {   
    //     UserDialogs.Instance.HideLoading();          
    // }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}