using NutriApp.Models;
using NutriApp.Services;

namespace NutriApp.Components.SlideCustomer;

public partial class SlideView : ContentView
{
    public static readonly BindableProperty ProteinaPercentageProperty =
        BindableProperty.Create(
            propertyName: nameof(ProteinaPercentage),
            returnType: typeof(int),
            declaringType: typeof(SlideView),
            defaultValue: 33,
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty CarboidratoPercentageProperty =
        BindableProperty.Create(
            propertyName: nameof(CarboidratoPercentage),
            returnType: typeof(int),
            declaringType: typeof(SlideView),
            defaultValue: 39,
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty LipidioPercentageProperty =
        BindableProperty.Create(
            propertyName: nameof(LipidioPercentage),
            returnType: typeof(int),
            declaringType: typeof(SlideView),
            defaultValue: 33,
            defaultBindingMode: BindingMode.TwoWay);

    public int ProteinaPercentage
    {
        get => (int)GetValue(ProteinaPercentageProperty);
        set => SetValue(ProteinaPercentageProperty, value);
    }

    public int CarboidratoPercentage
    {
        get => (int)GetValue(CarboidratoPercentageProperty);
        set => SetValue(CarboidratoPercentageProperty, value);
    }

    public int LipidioPercentage
    {
        get => (int)GetValue(LipidioPercentageProperty);
        set => SetValue(LipidioPercentageProperty, value);
    }

    private bool _inProgress;
    private bool _canMacroChangeValue;
    private bool _canChangeValue;

    public SlideView()
    {
        InitializeComponent();
        Fetch();
    }

    private void Fetch()
    {
        RangeSlider.RangeEnd = 69;
        RangeSlider.RangeStart = 33;
        _canChangeValue = true;
        ChangeValue();
    }

    private void ChangeValue()
    {
        if (!_canChangeValue) return;
        ProteinaPercentage = (int)RangeSlider.RangeStart;
        CarboidratoPercentage = (int)(RangeSlider.RangeEnd - RangeSlider.RangeStart);
        LipidioPercentage = (int)(100 - RangeSlider.RangeEnd);
        _canMacroChangeValue = true;
    }

    private void RangeSlider_OnValueChanged(object sender, EventArgs e)
    {
        ChangeValue();
    }

    private void CheckMacroPercentage(MacroNutrients macroNutrientType)
    {
        if (_inProgress || !_canMacroChangeValue) return;
        _inProgress = true;
        MacronutrientPercentModel macronutrientModel = new MacronutrientPercentModel()
            { Carb = CarboidratoPercentage, Lipid = LipidioPercentage, Protein = ProteinaPercentage };
        SlideViewService.CheckMacroPercentage(macronutrientModel, macroNutrientType);
        CarboidratoPercentage = macronutrientModel.Carb;
        LipidioPercentage = macronutrientModel.Lipid;
        ProteinaPercentage = macronutrientModel.Protein;
        ChangeValueMacro();
        _inProgress = false;
    }

    private void ChangeValueMacro()
    {
        _canChangeValue = false;
        RangeSlider.RangeEnd = ProteinaPercentage + CarboidratoPercentage;
        RangeSlider.RangeStart = ProteinaPercentage;
        _canChangeValue = true;
    }

    private void OnUnfocusedCarb(object sender, FocusEventArgs e)
    {
        CheckMacroPercentage(MacroNutrients.CARBOHYDRATES);
    }

    private void OnUnfocusedProtein(object sender, FocusEventArgs e)
    {
        CheckMacroPercentage(MacroNutrients.PROTEIN);
    }

    private void OnUnfocusedLip(object sender, FocusEventArgs e)
    {
        CheckMacroPercentage(MacroNutrients.LIPIDS);
    }
}