using SQLite;

namespace NutriApp.AppNutri.Model;

public class FoodPlanModel
{
    [PrimaryKey] public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Quantidade { get; set; }
    public string Medida { get; set; }
    public string Carboidratos { get; set; }
    public string Proteinas { get; set; }
    public string Lipidios { get; set; }
    public string Sodio { get; set; }
    public string FibraAlimentar { get; set; }
    public string Calcio { get; set; }
    public string Magnesio { get; set; }
    public string Manganes { get; set; }
    public string Selenio { get; set; }
    public string AcucarTotal { get; set; }
    public string GorduraSaturada { get; set; }
    public string GorduraMonoinsaturada { get; set; }
    public string GorduraPoliinsaturada { get; set; }
    public string GorduraTrans { get; set; }
    public string Fosforo { get; set; }
    public string Ferro { get; set; }
    public string Potassio { get; set; }
    public string Cobre { get; set; }
    public string Zinco { get; set; }
    public string VitaminaA { get; set; }
    public string VitaminaB1 { get; set; }
    public string VitaminaB2 { get; set; }
    public string VitaminaB6 { get; set; }
    public string VitaminaB3 { get; set; }
    public string VitaminaC { get; set; }
    public string VitaminaE { get; set; }
    public string VitaminaD { get; set; }
    public string ValorCalorico { get; set; }
    public int MealId { get; set; }
    public int MealFoodId { get; set; }
    public FoodReferences Fonte { get; set; }


    // * as análises estão sendo reavaliadas   0000
    // †Valores em branco nesta tabela: análises não solicitadas  00000
    // ††Teores alcoólicos (g/100g): 1 Cana, aguardente: 31,1 e 2 Cerveja, pilsen: 3,6. 
    // NA: não aplicável;  000000
    // Tr: traço 0000000

    public async Task<bool> LoadDataBase()
    {
        return true;
    }
}