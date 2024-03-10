namespace NutriApp.Models;

public class FoodDecimalModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Quantidade { get; set; }
    public double Medida { get; set; }
    public double Carboidratos { get; set; }
    public double Proteinas { get; set; }
    public double Lipidios { get; set; }
    public double Sodio { get; set; }
    public double FibraAlimentar { get; set; }
    public double ValorCalorico { get; set; }
        
    public double Calcio { get; set; }
    public double Magnesio { get; set; }
    public double Manganes { get; set; }
    public double Fosforo { get; set; }
    public double Ferro { get; set; }
    public double Potassio { get; set; }
    public double Cobre { get; set; }
    public double Zinco { get; set; }
    public double VitaminaA { get; set; }
    public double VitaminaB1 { get; set; }
    public double VitaminaB2 { get; set; }
    public double VitaminaB6 { get; set; }
    public double VitaminaB3 { get; set; }
    public double VitaminaC { get; set; }
    public int MealId { get; set; }
    public FoodReferences Reference { get; set; }
}