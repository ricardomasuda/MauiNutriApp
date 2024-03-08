namespace NutriApp.Models;

public enum NutrientsTypes
{
    QUANTIDADE,
    MEDIDA,
    CARBOIDRATO,
    PROTEINA,
    LIPIDIO,
    SODIO,
    FIBRA_ALIMENTAR,
    CALCIO,
    MAGNESIO,
    MANGANES,
    SELENIO,
    ACUCAR_TOTAL,
    GORDURA_SATURADA,
    GORDURA_MONOSINSATURADA,
    GORDURA_POLIINSATURADA,
    GORDURA_TRANS,
    FOSFORO,
    FERRO,
    POTASSIO,
    COBRE,
    ZINCO,
    VITAMINA_A,
    VITAMINA_B1,
    VITAMINA_B2,
    VITAMINA_B3,
    VITAMINA_B6,
    VITAMINA_C,
    VITAMINA_E,
    VITAMINA_D,
    VALOR_CALORICO,
}

public static class NutrientsBuild
{
    public static string AddUnitMeasure(NutrientsTypes nutrients)
    {
        switch (nutrients)
        {
            case NutrientsTypes.PROTEINA:
            case NutrientsTypes.QUANTIDADE:
            case NutrientsTypes.LIPIDIO:
            case NutrientsTypes.CARBOIDRATO:
            case NutrientsTypes.MEDIDA:
            case NutrientsTypes.GORDURA_SATURADA:
            case NutrientsTypes.GORDURA_MONOSINSATURADA:
            case NutrientsTypes.GORDURA_POLIINSATURADA:
            case NutrientsTypes.FIBRA_ALIMENTAR:
            case NutrientsTypes.GORDURA_TRANS: return "g";

            case NutrientsTypes.VALOR_CALORICO: return "kcal";

            case NutrientsTypes.CALCIO:
            case NutrientsTypes.MAGNESIO:
            case NutrientsTypes.MANGANES:
            case NutrientsTypes.ACUCAR_TOTAL:
            case NutrientsTypes.FOSFORO:
            case NutrientsTypes.FERRO:
            case NutrientsTypes.POTASSIO:
            case NutrientsTypes.COBRE:
            case NutrientsTypes.ZINCO:
            case NutrientsTypes.VITAMINA_B1:
            case NutrientsTypes.VITAMINA_B2:
            case NutrientsTypes.VITAMINA_B3:
            case NutrientsTypes.VITAMINA_B6:
            case NutrientsTypes.VITAMINA_C:
            case NutrientsTypes.VITAMINA_E:
            case NutrientsTypes.VITAMINA_D: return "mg";

            case NutrientsTypes.SODIO:
            case NutrientsTypes.SELENIO:
            case NutrientsTypes.VITAMINA_A: return "mcg";
        }

        throw new Exception("Erro ao converter Grandeza");
    }
}