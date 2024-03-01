namespace NutriApp.AppNutri.service;

public static class WeightAdjustmentService
{
    public static string VerifyAdequacyWeight(double adequacyWeight)
    {
        return adequacyWeight switch
        {
            <= 70.0 => "Desnutrição Grave",
            <= 80.0 and > 70.00 => "Desnutrição moderada",
            <= 90.0 and > 80.00 => "Desnutrição Leve",
            <= 110.00 and > 90.00 => "Normal",
            <= 120 and > 110.00 => "Sobrepeso",
            > 120 => "Obesidade ",
            _ => ""
        };
    }
}