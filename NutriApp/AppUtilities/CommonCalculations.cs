using System.Globalization;

namespace NutriApp.AppUtilities;

public static class CommonCalculations
{
    public static double HeightSquared(double altura)
    {
        return altura * altura;
    }

    public static double ConverterDouble(string value, int decimalPlaces = 0)
    {
        try
        {
            if (value == "0") return 0;
            var replace = value.Replace(",", ".");
            var result = double.Parse(replace, CultureInfo.InvariantCulture);
            if (decimalPlaces != 0)
            {
                result = Math.Round(result, decimalPlaces);
            }

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }

    public static string RoundNutrient(string macroNutrient, int decimalVigula)
    {
        return Math.Round(ConverterDouble(macroNutrient), decimalVigula).ToString();
    }

    public static string RoundNutrient(string nutrient)
    {
        return Math.Round(ConverterDouble(nutrient), 2).ToString();
    }

    public static bool IsDigit(string valorReferencia)
    {
        return double.TryParse(valorReferencia, out _);
    }

    public static int DecimalDigits(this decimal n)
    {
        return n.ToString(CultureInfo.InvariantCulture)
            .SkipWhile(c => c != '.')
            .Skip(1)
            .Count();
    }

    public static double Proportion(double valorA, double valorB, double proportion)
    {
        return (valorA * proportion) / valorB;
    }

    public static string Proportion(string valorA, double valorB, double proportion = 100)
    {
        try
        {
            //100 referente a medida 100 g
            return IsDigit(valorA)
                ? (ConverterDouble(valorA) * valorB / proportion).ToString()
                : valorA;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return string.Empty;
        }
    }

    public static bool IsDeletion(this TextChangedEventArgs e)
    {
        return !string.IsNullOrEmpty(e.OldTextValue) && e.OldTextValue.Length > e.NewTextValue.Length;
    }

    public static List<string> DivideUnitMeasureNutrients(string nutrition)
    {
        List<string> nutritionGrandeza = new();
        var charsToRemove = new[] { "g", "m", "mg", "kcal" };
        foreach (var grandeza in charsToRemove)
        {
            if (nutrition.Contains(grandeza))
            {
                nutritionGrandeza.Add((nutrition.Replace(grandeza, string.Empty)).Trim());
                nutritionGrandeza.Add(grandeza);
            }
        }

        return nutritionGrandeza;
    }
}