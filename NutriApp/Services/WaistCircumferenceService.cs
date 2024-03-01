using NutriApp.AppNutri.Model;

namespace NutriApp.AppNutri.service;

public static class WaistCircumferenceService
{
    public static string GetCalfCircumference(double circumference)
    {
        return circumference >= 31 ? "Eutrofia" : "Risco de desnutrição";
    }

    public static string GetWaistCircumferenceRatio(double circumference, double age, Genders genders)
    {
        if (genders == Genders.Female)
        {
            return GetFemaleWaistRatio(circumference, age);
        }

        if (genders == Genders.Male)
        {
            return GetMaleWaistRatio(circumference, age);
        }

        return "Não foi possível calcular";
    }

    private static string GetFemaleWaistRatio(double circumference, double age)
    {
        return age switch
        {
            > 20 and < 30 => circumference switch
            {
                var n when n < 0.71 => "Baixo",
                var n when n >= 0.71 && n <= 0.77 => "Moderado",
                var n when n >= 0.78 && n <= 0.82 => "Alto",
                var n when n > 0.82 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 30 and < 40 => circumference switch
            {
                var n when n < 0.71 => "Baixo",
                var n when n >= 0.71 && n <= 0.78 => "Moderado",
                var n when n > 0.78 && n <= 0.84 => "Alto",
                var n when n > 0.84 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 40 and < 50 => circumference switch
            {
                var n when n < 0.73 => "Baixo",
                var n when n >= 0.73 && n < 0.80 => "Moderado",
                var n when n >= 0.80 && n <= 0.87 => "Alto",
                var n when n > 0.87 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 50 and < 60 => circumference switch
            {
                var n when n < 0.74 => "Baixo",
                var n when n >= 0.74 && n <= 0.81 => "Moderado",
                var n when n > 0.81 && n <= 0.88 => "Alto",
                var n when n > 0.88 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 60 and < 70 => circumference switch
            {
                var n when n < 0.76 => "Baixo",
                var n when n >= 0.76 && n <= 0.83 => "Moderado",
                var n when n > 0.83 && n <= 0.90 => "Alto",
                var n when n > 0.90 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            _ => "Não foi possível calcular"
        };
    }

    private static string GetMaleWaistRatio(double circumference, double age)
    {
        return age switch
        {
            > 20 and < 30 => circumference switch
            {
                var n when n < 0.83 => "Baixo",
                var n when n >= 0.83 && n <= 0.88 => "Moderado",
                var n when n > 0.88 && n <= 0.94 => "Alto",
                var n when n > 0.94 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 30 and < 40 => circumference switch
            {
                var n when n < 0.84 => "Baixo",
                var n when n >= 0.84 && n <= 0.91 => "Moderado",
                var n when n > 0.91 && n <= 0.96 => "Alto",
                var n when n > 0.96 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 40 and < 50 => circumference switch
            {
                var n when n < 0.88 => "Baixo",
                var n when n >= 0.88 && n <= 0.95 => "Moderado",
                var n when n > 0.95 && n <= 1.00 => "Alto",
                var n when n > 1.00 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 50 and < 60 => circumference switch
            {
                var n when n < 0.90 => "Baixo",
                var n when n >= 0.90 && n <= 0.96 => "Moderado",
                var n when n > 0.96 && n <= 1.00 => "Alto",
                var n when n > 1.02 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            >= 60 and < 70 => circumference switch
            {
                var n when n < 0.91 => "Baixo",
                var n and >= 0.91 when n <= 0.98 => "Moderado",
                var n when n > 0.99 && n <= 1.03 => "Alto",
                var n when n > 1.03 => "Muito Alto",
                _ => "Não foi possível calcular"
            },
            _ => "Não foi possível calcular"
        };
    }
}