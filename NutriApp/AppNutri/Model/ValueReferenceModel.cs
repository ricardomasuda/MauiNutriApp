using SQLite;

namespace NutriApp.AppNutri.Model;

public class ValueReferenceModel
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public int FoodPlanId { get; set; }
    public double Peso { get; set; }
    public double Energia { get; set; }
    public int Carboidratos { get; set; }
    public int Proteinas { get; set; }
    public int Lipidios { get; set; }
}