namespace NutriApp.Converters;

public static class AnthropometricEvaluationConverter
{
    public static AnthropometricEvaluationModel ConvertModelForPage(AnthropometricEvaluationPageModel anthropometricEvaluationPageModel)
    {
        AnthropometricEvaluationModel anthropometricEvaluationModel = new ();
        anthropometricEvaluationModel.Chest = Convert.ToDouble(anthropometricEvaluationPageModel.Chest);
        anthropometricEvaluationModel.Abdominal = Convert.ToDouble(anthropometricEvaluationPageModel.Abdominal);
        anthropometricEvaluationModel.Biceps = Convert.ToDouble(anthropometricEvaluationPageModel.Biceps);
        anthropometricEvaluationModel.MedialAxilla = Convert.ToDouble(anthropometricEvaluationPageModel.MedialAxilla);
        anthropometricEvaluationModel.MiddleAxillary = Convert.ToDouble(anthropometricEvaluationPageModel.MiddleAxillary);
        anthropometricEvaluationModel.LateralCalf = Convert.ToDouble(anthropometricEvaluationPageModel.LateralCalf);
        anthropometricEvaluationModel.Triceps = Convert.ToDouble(anthropometricEvaluationPageModel.Triceps);
        anthropometricEvaluationModel.Thigh = Convert.ToDouble(anthropometricEvaluationPageModel.Thigh);
        anthropometricEvaluationModel.SubScapular = Convert.ToDouble(anthropometricEvaluationPageModel.SubScapular);
        anthropometricEvaluationModel.Suprailiac = Convert.ToDouble(anthropometricEvaluationPageModel.Suprailiac);
        

        return anthropometricEvaluationModel;
    }
}