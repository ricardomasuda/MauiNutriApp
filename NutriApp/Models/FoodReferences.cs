namespace NutriApp.Models;

public enum FoodReferences
{
    NONE,
    TacoQuartaEdição = 2,
    IBGE = 1
}

public static class FoodReference
{
    public static string GetReference(FoodReferences reference)
    {
        switch (reference)
        {
            case FoodReferences.TacoQuartaEdição: return "Taco Quarta Edição";
            case FoodReferences.IBGE: return "IBGE";
            default:
                return null;
        }
    }
}