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

    protected T GetQueryValue<T>(IDictionary<string, object> query, string key) where T : class
    {
        if (query.TryGetValue(key, out var value))
        {
            return value as T;
        }

        return null;
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string nameProperty)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
    }
}