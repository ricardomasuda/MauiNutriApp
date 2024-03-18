using System.ComponentModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NutriApp.Components;

public partial class BaseViewModel : ObservableObject 
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
    protected async void InfoToaster(string message, ToastDuration toastDuration)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        double fontSize = 14;
        var toast = Toast.Make(message, toastDuration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }
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