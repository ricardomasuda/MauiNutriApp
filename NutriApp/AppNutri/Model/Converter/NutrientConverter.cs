using System.Globalization;
using NutriApp.AppNutri.Utils;

namespace NutriApp.AppNutri.Model.Converter;

public class NutrientConverter : IValueConverter, IMarkupExtension
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            if (string.IsNullOrWhiteSpace(value.ToString())) return value;

            var list = CommonCalculations.DivideUnitMeasureNutrients(value.ToString());
            if (list.Count == 0) return value;

            value = CommonCalculations.ConverterDouble(list[0], 2);
            value = value.ToString().Replace(".", ",");
            value = $"{value} {list[1]}";
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}