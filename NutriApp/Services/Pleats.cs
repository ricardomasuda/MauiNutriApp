namespace NutriApp.Services;

public static class Pleats
{
    public static double BodyDensitySevenPleatsJacksonAndPollock(AnthropometricEvaluationModel anthropometricEvaluationModel, int age, Genders genders)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        switch (genders)
        {
            case Genders.Male:
                return (1.112 - (0.00043499 * sumPleats) + 0.00000055 * Math.Pow(sumPleats, 2) -
                        (0.00028826 * age));
            case Genders.Female:
                return (1.097 - (0.00046971 * sumPleats) + 0.00000056 * Math.Pow(sumPleats, 2) -
                        (0.00012828 * age));
            default:
                return 0;
        }
    }

    public static double BodyDensityDurninAndWomersley(AnthropometricEvaluationModel anthropometricEvaluationModel, int age, Genders genders)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        switch (genders)
        {
            case Genders.Male:
                switch (age)
                {
                    case < 20:
                        return 1.1620 - (0.630 * Math.Log10(sumPleats));
                    case >= 20 and < 30:
                        return 1.1631 - (0.632 * Math.Log10(sumPleats));
                    case >= 30 and < 40:
                        return 1.1422 - (0.0544 * Math.Log10(sumPleats));
                    case >= 40 and < 50:
                        return 1.1620 - (0.700 * Math.Log10(sumPleats));
                    default:
                        return 1.1715 - (0.0779 * Math.Log10(sumPleats));
                }
            case Genders.Female:
                switch (age)
                {
                    case < 20:
                        return 1.1549 - (0.0678 * Math.Log10(sumPleats));
                    case >= 20 and < 30:
                        return 1.1599 - (0.0717 * Math.Log10(sumPleats));
                    case >= 30 and < 40:
                        return 1.1423 - (0.632 * Math.Log10(sumPleats));
                    case < 50 and >= 40:
                        return 1.1333 - (0.0612 * Math.Log10(sumPleats));
                    default:
                        return 1.1339 - (0.0645 * Math.Log10(sumPleats));
                }
            default: return 0;
        }
    }

    public static double BodyDensityFaulkner(AnthropometricEvaluationModel anthropometricEvaluationModel)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        return sumPleats * 0.153 + 5.783;
    }

    public static double BodyDensityPetroski(AnthropometricEvaluationModel anthropometricEvaluationModel, int age,
        Genders genders)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        switch (genders)
        {
            case Genders.Male: return 1.10726863 - 0.00081201 * sumPleats + 0.0000021 * sumPleats - 0.00041761 * age;
            case Genders.Female: return 1.19547130 - 0.07513507 * Math.Log10(sumPleats) - 0.00041072 * age;
            default: return 0;
        }
    }

    //Jackson & Pollock 
    public static double BodyDensityThreePleatsJacksonAndPollock(
        AnthropometricEvaluationModel anthropometricEvaluationModel, int age, Genders genders)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        switch (genders)
        {
            case Genders.Male:
                return (1.10938 - (0.0008267 * sumPleats) + (0.0000016 * Math.Pow(sumPleats, 2)) -
                        (0.0002574 * age));
            case Genders.Female:
                return (1.0994921 - (0.0009929 * sumPleats) + (0.0000023 * Math.Pow(sumPleats, 2)) -
                        0.0001392 * age);
            default:
                return 0;
        }
    }

    //Guedes
    public static double BodyDensityGuedes(AnthropometricEvaluationModel anthropometricEvaluationModel, Genders genders)
    {
        var sumPleats = AnthropometricEvaluationService.SumSevenPleats(anthropometricEvaluationModel);
        switch (genders)
        {
            case Genders.Male: return 1.17136 - 0.06706 * Math.Log10(sumPleats);
            case Genders.Female: return 1.16650 - 0.07063 * Math.Log10(sumPleats);
            default: return 0;
        }
    }
}