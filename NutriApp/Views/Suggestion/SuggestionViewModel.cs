using NutriApp.Components;

namespace NutriApp.Views.Suggestion;

public class SuggestionViewModel : BaseViewModel
{
    private string _bodyText;

    public string BodyText
    {
        get => _bodyText;
        set
        {
            _bodyText = value;
            OnPropertyChanged("BodyText");
        }
    }

    private bool _hasErrorBodyText;

    public bool HasErrorBodyText
    {
        get => _hasErrorBodyText;
        set
        {
            _hasErrorBodyText = value;
            OnPropertyChanged("HasErrorBodyText");
        }
    }

    public Command SendEmailCommand { get; set; }

    public SuggestionViewModel()
    {
        SendEmailCommand = new Command(EmailSugestao);
    }

    private bool Validate()
    {
        HasErrorBodyText = string.IsNullOrWhiteSpace(BodyText);

        return !HasErrorBodyText;
    }

    private async void EmailSugestao()
    {
        if (!Validate()) return;

        try
        {
            var toList = new List<string> { "mricardo1611@gmail.com" };
            const string title = "Sugestão para Guia Do Nutricionista";

            if (await Utils.Utils.SendEmail(title, BodyText, toList)) return;
            if (!await Utils.Utils.SendWebEmail(title, BodyText, toList[0]))
            {
                await App.NavPage.DisplayAlert("Erro", "Erro ao enviar email", "Ok");
            }
        }
        catch (Exception e)
        {
            await App.NavPage.DisplayAlert("Erro", "Erro ao enviar sugestão", "ok");
            throw;
        }
    }
}