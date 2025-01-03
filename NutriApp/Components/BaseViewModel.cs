using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace NutriApp.Components;

public partial class BaseViewModel : ObservableObject 
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;
    
    public bool IsNotBusy => !IsBusy;

    [ObservableProperty] private string _title;

    protected async void InfoToaster(string message, ToastDuration toastDuration)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        double fontSize = 14;
        var toast = Toast.Make(message, toastDuration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }

    protected double GetScreenWith()
    {
       return (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
    }
    
    protected double GetScreenHeight()
    {
        return (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
    }
    
    protected T GetQueryValue<T>(IDictionary<string, object> query, string key)
    {
        if (query.TryGetValue(key, out var value))
        {
            if (value is T typedValue)
            {
                return typedValue;
            }
        }

        return default(T);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}