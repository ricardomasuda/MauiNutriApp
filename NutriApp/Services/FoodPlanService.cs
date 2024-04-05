namespace NutriApp.Services;

public class FoodPlanService
{
       public static MacronutrientModel BuildMacronutrient(FoodModel foodModel)
        {
            MacronutrientModel macronutrientModel = new()
            {
                Protein = CommonCalculations.ConverterDouble(foodModel.Proteinas.Replace("g", string.Empty)),
                Carb = CommonCalculations.ConverterDouble(foodModel.Carboidratos.Replace("g", string.Empty)),
                Lipid = CommonCalculations.ConverterDouble(foodModel.Lipidios.Replace("g", string.Empty)),
            };

            return macronutrientModel;
        }
        
        public static MacronutrientModel CalculateMacronutrientPercentage(MacronutrientModel macroValues)
        {
            double proteinCal = ConvertMacronutrientToCalories(macroValues.Protein, MacroNutrients.PROTEIN);
            double carbCal = ConvertMacronutrientToCalories(macroValues.Carb, MacroNutrients.CARBOHYDRATES);
            double lipidCal = ConvertMacronutrientToCalories(macroValues.Lipid, MacroNutrients.LIPIDS);

            var totalCal = proteinCal + carbCal + lipidCal;
            return new MacronutrientModel()
            {
                Protein = PercentageOfTotalCalories(totalCal, proteinCal, 1),
                Carb = PercentageOfTotalCalories(totalCal, carbCal, 1),
                Lipid = PercentageOfTotalCalories(totalCal, lipidCal, 1)
            };
        }
        
        public static double CalculateReferenceValue(string calories, int percent, MacroNutrients macroNutrients)
        {
            var caloriesAux = CommonCalculations.ConverterDouble(calories);
            var result = ProportionPercent(caloriesAux, percent);
            
            return Math.Round(ConvertCaloriesToMacronutrient(result, macroNutrients), 2);
        }
        
        public static double CalculateFoodPlan(string calories, string macro, MacroNutrients macroNutrients)
        {
            double caloriesAux = CommonCalculations.ConverterDouble(calories);
            double macroAux = CommonCalculations.ConverterDouble(macro);
            double result = ConvertCaloriesToMacronutrient(caloriesAux, macroNutrients);

            if (result == 0) return 0;
            return PercentageOfTotalCalories(result, macroAux);
        }
        
        private static double ConvertCaloriesToMacronutrient(double calories, MacroNutrients macroNutrients)
        {
            switch (macroNutrients)
            {
                case MacroNutrients.CARBOHYDRATES or MacroNutrients.PROTEIN:
                    return calories / 4;
                case MacroNutrients.LIPIDS:
                    return calories / 9;
                default:
                    return 0;
            }
        }

        private static double ConvertMacronutrientToCalories(double macro, MacroNutrients macroNutrients)
        {
            switch (macroNutrients)
            {
                case MacroNutrients.CARBOHYDRATES or MacroNutrients.PROTEIN:
                    return macro * 4;
                case MacroNutrients.LIPIDS:
                    return macro * 9;
                default:
                    return 0;
            }
        }

        private static double ProportionPercent(double calories, int percent)
        {
            return calories * (percent / 100.0);
        }

        private static double PercentageOfTotalCalories(double calories, double macro, int decimalPlaces = 2)
        {
            if (calories <= 0) return 0;

            double proportion = (macro * 100) / calories;
            return Math.Round(proportion, decimalPlaces);
        }
}