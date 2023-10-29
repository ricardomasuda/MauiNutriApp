namespace NutriApp.AppNutri.Model;

public enum Genders
{
    Male,
    Female
}

public static class GenderUtils
{
    public static Genders ConverterGender(string genderType)
    {
        switch (genderType.ToUpper().Trim())
        {
            case "HOMEM":
            case "MASCULINO":
                return Genders.Male;
            case "MULHER":
            case "FEMINO":
                return Genders.Female;
        }

        throw new Exception("Erro ao converter gênero");
    }
}