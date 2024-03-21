using System.ComponentModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NutriApp.Components;

public partial class BaseViewModel : ObservableObject 
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    [ObservableProperty] private string _title;

    public bool IsNotBusy => !IsBusy;

    protected async void InfoToaster(string message, ToastDuration toastDuration)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        double fontSize = 14;
        var toast = Toast.Make(message, toastDuration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}