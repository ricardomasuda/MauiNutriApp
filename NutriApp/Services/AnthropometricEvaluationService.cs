namespace NutriApp.Services;

public class AnthropometricEvaluationService
{
    public static AnthropometricEvaluationResultModel Calculate(AnthropometricEvaluationTypeEnum anthropometricEvaluationTypeEnum, AnthropometricEvaluationModel anthropometricEvaluationModel, double weigh, int age = 0 , Genders genders = Genders.Male)
        {
            var anthropometricEvaluationResultModel = new AnthropometricEvaluationResultModel();
            anthropometricEvaluationResultModel.BodyDensity = CalculateBodyDensity(anthropometricEvaluationTypeEnum, anthropometricEvaluationModel, age, genders);
            anthropometricEvaluationResultModel.BodyFatPercentage = SiriFormula(anthropometricEvaluationResultModel.BodyDensity, age, genders);
            anthropometricEvaluationResultModel.BodyLeanPercentage = 100 - anthropometricEvaluationResultModel.BodyFatPercentage;
            anthropometricEvaluationResultModel.BodyFat = CommonCalculations.Proportion(Convert.ToDouble(weigh), 100,anthropometricEvaluationResultModel.BodyFatPercentage);
            anthropometricEvaluationResultModel.BodyLean = CommonCalculations.Proportion(Convert.ToDouble(weigh),100,anthropometricEvaluationResultModel.BodyLeanPercentage);
            anthropometricEvaluationResultModel.SumPleats = SumSevenPleats(anthropometricEvaluationModel);
            return anthropometricEvaluationResultModel;
        }

        private static double CalculateBodyDensity(AnthropometricEvaluationTypeEnum anthropometricEvaluationTypeEnum, AnthropometricEvaluationModel anthropometricEvaluationModel, int age = 0 , Genders genders = Genders.Male)
        {
            switch (anthropometricEvaluationTypeEnum)
            {
                case AnthropometricEvaluationTypeEnum.JacksonAndPollockThreePleats: return Pleats.BodyDensityThreePleatsJacksonAndPollock(anthropometricEvaluationModel, age, genders);
                case AnthropometricEvaluationTypeEnum.Guedes: return Pleats.BodyDensityGuedes(anthropometricEvaluationModel, genders);
                case AnthropometricEvaluationTypeEnum.DurninAndWomersley: return Pleats.BodyDensityDurninAndWomersley(anthropometricEvaluationModel, age, genders);
                case AnthropometricEvaluationTypeEnum.Faulkner: return Pleats.BodyDensityFaulkner(anthropometricEvaluationModel);
                case AnthropometricEvaluationTypeEnum.Petroski: return Pleats.BodyDensityPetroski(anthropometricEvaluationModel, age, genders);
                case AnthropometricEvaluationTypeEnum.JacksonAndPollockSevenPleats: return Pleats.BodyDensitySevenPleatsJacksonAndPollock(anthropometricEvaluationModel, age, genders);
                default: return 0;
            }
        }

        private static double SiriFormula(double bodyDensity, int age, Genders genders)
        {
            switch (genders)
            {
                case Genders.Male:
                    switch (age)
                    {
                        case 7:
                        case 8: return (538 / bodyDensity) - 497;
                        case 9:
                        case 10: return (538 / bodyDensity) - 497;
                        case 11:
                        case 12: return (523 / bodyDensity) - 481;
                        case 13:
                        case 14: return (507 / bodyDensity) - 464;
                        case 15:
                        case 16: return (503 / bodyDensity) - 459;
                        case 17:
                        case 18:
                        case 19: return (498 / bodyDensity) - 453;
                        default: return (495 / bodyDensity) - 450;
                    }
                case Genders.Female:
                    switch (age)
                    {
                        case 7:
                        case 8: return (543 / bodyDensity) - 503;
                        case 9:
                        case 10: return (535 / bodyDensity) - 495;
                        case 11:
                        case 12: return (525 / bodyDensity) - 484;
                        case 13:
                        case 14: return (512 / bodyDensity) - 469;
                        case 15:
                        case 16: return (507 / bodyDensity) - 464;
                        case 17:
                        case 18:
                        case 19: return (505 / bodyDensity) - 462;
                        default: return (503 / bodyDensity) - 459;
                    }
                default: return 0;
            }
        }

        public static double SumSevenPleats(AnthropometricEvaluationModel anthropometricEvaluationModel)
        {
            return anthropometricEvaluationModel.Triceps +
                   anthropometricEvaluationModel.SubScapular +
                   anthropometricEvaluationModel.Suprailiac +
                   anthropometricEvaluationModel.Abdominal +
                   anthropometricEvaluationModel.Biceps +
                   anthropometricEvaluationModel.Thigh +
                   anthropometricEvaluationModel.Chest +
                   anthropometricEvaluationModel.MiddleAxillary +
                   anthropometricEvaluationModel.LateralCalf +
                   anthropometricEvaluationModel.MedialAxilla;
        }
}