using NutriApp.Models;

namespace NutriApp.Services;

public class SlideViewService
{
    public static MacronutrientPercentModel CheckMacroPercentage(MacronutrientPercentModel macro, MacroNutrients macroNutrients)
    {
        if (Validate(macro))
        {
            switch (macroNutrients)
            {
                case MacroNutrients.PROTEIN:
                    (macro.Carb, macro.Protein, macro.Lipid) = SlideCalculationMacro(macro.Lipid, macro.Protein);
                    break;
                case MacroNutrients.CARBOHYDRATES:
                    (macro.Protein, macro.Carb, macro.Lipid) = SlideCalculationMacro(macro.Lipid, macro.Carb);
                    break;
                case MacroNutrients.LIPIDS:
                    (macro.Carb, macro.Lipid, macro.Protein) = SlideCalculationMacro(macro.Protein, macro.Lipid);
                    break;
            }
        }

        return macro;
    }
        
    private static bool Validate(MacronutrientPercentModel macro)
    {
        int somaMacro = macro.Carb + macro.Lipid + macro.Protein;
        return somaMacro is > 100 or < 100;
    }

    private static (int MacroResult, int MacroInput , int MacroFixes) SlideCalculationMacro(int macroFixed, int macroInput)
    {
        if (macroInput > 100)
        {
            return (0, 100, 0);
        }
        var result = 100 - (macroFixed + macroInput);
        if (result < 0)
        {
            macroFixed += result;
            return (0, macroInput, macroFixed);
        }
        return (result, macroInput, macroFixed);
    }
}
