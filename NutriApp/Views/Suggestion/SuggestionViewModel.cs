
namespace NutriApp.Views.Suggestion;

public partial class SuggestionViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _bodyText;
    [ObservableProperty]
    private bool _hasErrorBodyText;
    
    [RelayCommand]
    private async Task SendEmail()
    {
        if (!Validate()) return;

        try
        {
            var toList = new List<string> { "mricardo1611@gmail.com" };
            const string title = "Sugestão para Guia Do Nutricionista";

            if (await Utils.SendEmail(title, BodyText, toList)) return;
            if (!await Utils.SendWebEmail(title, BodyText, toList[0]))
            {
                await Shell.Current.DisplayAlert("Erro", "Erro ao enviar email", "Ok");
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Erro", "Erro ao enviar sugestão", "ok");
        }
    }
    
    private bool Validate()
    {
        HasErrorBodyText = string.IsNullOrWhiteSpace(BodyText);

        return !HasErrorBodyText;
    }
}