using NutriApp.Models;

namespace NutriApp.Services.AnthropometricEvaluation;

public static class BodyCompositionService
{
    public static BoneDiameterModel Calculate(PatientModel patientModel, double bodyLean)
    {
        BoneDiameterModel boneDiameterModel = new();
        boneDiameterModel.BoneWeight = CalculateBoneMass(patientModel.Height, patientModel.Wrist, patientModel.Femur);
        boneDiameterModel.ResidualWeight =CalculateResidualWeight(patientModel.Weigh, patientModel.Gender);
        boneDiameterModel.MuscleWeight = bodyLean - (boneDiameterModel.BoneWeight + boneDiameterModel.ResidualWeight);
        return boneDiameterModel;
    }
        
    public static double CalculateBoneMass(double height, double wrist, double femur)
    {
        double boneMass = Math.Pow(height, 2) * ConvertCmForM(wrist) * ConvertCmForM(femur) * 400;
        boneMass = Math.Pow(boneMass, 0.712) * 3.02;
        return Math.Round(boneMass, 2);
    }

    private static double ConvertCmForM(double valueCm)
    {
        return valueCm / 100;
    }
        
    public static double CalculateResidualWeight(double weight, Genders gender)
    {
        double residualWeight;
        switch (gender)
        {
            case Genders.Male:
                residualWeight = weight * 0.241;
                break;
            case Genders.Female:
                residualWeight = weight * 0.209;
                break;
            default:
                throw new ArgumentException("Invalid gender specified. Must be 'male' or 'female'.", nameof(gender));
        }
        return Math.Round(residualWeight, 2);
    }
}