namespace NutriApp.Components;

public interface IBaseViewModel
{
    void OnPropertyChanged(string nameProperty);
    // Se você deseja manter os métodos da classe BaseViewModel na interface,
    // você pode adicionar os métodos aqui como métodos da interface também.
    // Exemplo:
    // void ErrorToaster(string message = "Error!", int durationInSeconds = 3, bool showInBottom = false);
    // void WarningToaster(string message = "Atenção!", int durationInSeconds = 3, bool showInBottom = false);
    // void InfoToaster(string message, int durationInSeconds = 3, bool showInBottom = false);
    // void SuccessToaster(string message = "Successo!", int durationInSeconds = 3, bool showInBottom = false);
    // void ShowLoading(string text = "Carregando", MaskType type = MaskType.Black);
    // void HideLoading();
}