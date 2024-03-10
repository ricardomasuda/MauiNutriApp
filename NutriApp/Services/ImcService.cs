using NutriApp.Models;

namespace NutriApp.Services;

public static class ImcService
{
    public static string CheckImc(double imc , PersonAgeType personAgeType)
    {
        return personAgeType switch
        {
            PersonAgeType.Adulto => CheckAdultImc(imc),
            PersonAgeType.Idoso => CheckSeniorImc(imc),
            _ => throw new ArgumentOutOfRangeException(nameof(personAgeType), personAgeType, null)
        };
    }

    private static string CheckAdultImc(double imc)
    {
        return imc switch
        {
            < 16.0 => "Magreza grau III",
            <= 16.99 and >= 16.1 => "Magreza grau II",
            <= 18.49 and >= 17.0 => "Magreza grau I",
            <= 24.99 and >= 18.5 => "Normal (eutrófico)",
            <= 29.99 and >= 25.0 => "Sobrepeso",
            <= 34.99 and >= 30.0 => "Obesidade I",
            <= 39.99 and >= 35.0 => "Obesidade II",
            >= 40 => "Obesidade III",
            _ => ""
        };
    }

    private static string CheckSeniorImc(double imc)
    {
        return imc switch
        {
            < 22.0 => "Baixo peso",
            <= 27.0 and >= 22 => "Adequado ou eutrófico",
            >= 27.0 => "Sobrepeso",
            _ => ""
        };
    }
}