using System.Globalization;

namespace NutriApp.Utils;

public static class Utils
{
    public static async Task<bool> SendEmail(string subject, string body, List<string> recipients)
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = recipients,
            };
            await Email.ComposeAsync(message);
            return true;
        }
        catch (FeatureNotSupportedException fbsEx)
        {
            //await App.NavPage.DisplayAlert("Erro","Seu celular não suporta enviar o email","Ok");
            return false;
        }
        catch (Exception ex)
        {
            //await App.NavPage.DisplayAlert("Erro","Erro ao enviar o email","Ok");
            return false;
        }
    }

    public static async Task<bool> SendWebEmail(string subject, string body, string recipients)
    {
        try
        {
            await Launcher.OpenAsync($"mailto:{recipients}?subject={subject}&body={body}");
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string RemoveUnityMeasure(string nutrient, string unityMeasure)
    {
        return string.IsNullOrEmpty(nutrient) ? null : nutrient.Replace(unityMeasure, "").Trim();
    }

    public static string RemoveUnityMeasure(string nutrient)
    {
        var charsToRemove = new[] { "g", "m", "mg", "kcal" };
        foreach (var unityMeasure in charsToRemove)
        {
            if (nutrient.Contains(unityMeasure))
            {
                return string.IsNullOrEmpty(nutrient) ? null : nutrient.Replace(unityMeasure, "").Trim();
            }
        }

        return nutrient;
    }

    public static bool ContainsAlphabetCharacter(string texto)
    {
        foreach (char c in texto)
        {
            if (Char.IsLetter(c))
            {
                return true;
            }
        }

        return false;
    }

    public static async Task ShareFile(Stream image)
    {
        var cacheFile = Path.Combine(FileSystem.CacheDirectory, "Relatório.png");
        using (var file = new FileStream(cacheFile, FileMode.Create, FileAccess.Write))
        {
            await image.CopyToAsync(file);
        }

        await Share.RequestAsync(new ShareFileRequest()
        {
            Title = "Relatorio",
            File = new ShareFile(cacheFile)
        });
    }

    public static double ConvertHeight(string height)
    {
        NumberFormatInfo format = new()
        {
            NumberDecimalSeparator = ","
        };
        return double.Parse(height, format);
    }
}