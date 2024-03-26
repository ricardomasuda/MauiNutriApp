namespace NutriApp.AppUtilities;

public static class EvaluationCalculations
    {
        public static double Imc(double height, double currentWeight)
        {
            return Math.Round(currentWeight / CommonCalculations.HeightSquared(height), 2);
        }

        public static double IdealWeight(double imc, double height)
        {
            return Math.Round(imc * CommonCalculations.HeightSquared(height), 2);
        }

        public static double AdjustedWeight(double idealWeight, double currentWeight, WeightTypes weightType)
        {
            switch (weightType)
            {
                case WeightTypes.MALNUTRITION:
                    return (idealWeight - currentWeight) * 0.25 + currentWeight;
                case WeightTypes.OBESITY:
                    return (currentWeight - idealWeight) * 0.25 + idealWeight;
                default:
                    return 0;
            }
        }

        public static double EstimatedHeight(double kneeHeight, double age, Genders genders)
        {
            try
            {
                if (genders == Genders.Male) return (2.02 * kneeHeight) - (0.04 * age) + 64.19;
                return Convert.ToInt16((1.83 * kneeHeight) - (0.24 * age) + 84.88);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        //FONTE: CHUMLEA et al., 1988.
        public static double EstimateWeight(double circumferenceLeg, double kneeHeight, double brachialMuscleCircumference, double subscapularSkinfold, Genders genders)
        {
            try
            {
                if (genders == Genders.Male) return (0.98 * circumferenceLeg) + (1.16 * kneeHeight) + (1.73 * brachialMuscleCircumference) + (0.4 * subscapularSkinfold) - 81.69;
                return (1.27 * circumferenceLeg) + (0.87 * kneeHeight) + (0.98 * brachialMuscleCircumference) + (0.4 * subscapularSkinfold) - 62.35;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
        
        //FONTE: RABITO et al., 2006
        public static double EstimateWeight(double armCircumference, double waistCircumference, double calfCircumference, Genders gender)
        {
            int genderNumber = gender == Genders.Male ? 1 : 0;
            double estimatedWeight = (0.5759 * armCircumference) + (0.5263 * waistCircumference) + (1.2452 * calfCircumference) - (4.8689 * genderNumber) - 32.9241;
            return estimatedWeight;
        }

        public static double AdequacyWeight(double idealWeight, double currentWeight)
        {
            try
            {
                return (currentWeight * 100) / idealWeight;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        public static double CircumferenceWaist(double abdominalCircumference, double hipCircumference)
        {
            try
            {
                return abdominalCircumference / hipCircumference;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }