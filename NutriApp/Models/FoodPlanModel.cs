using SQLite;

namespace NutriApp.Models;

public class FoodPlanModel
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string ValorTotal {get; set; }
    public string Carboidratos { get; set; }
    public string Proteinas { get; set; }
    public string Lipidios { get; set; }
    [Ignore]
    public string CarboidratosPorcentagem { get; set; }
    [Ignore]
    public string ProteinasPorcentagem { get; set; }
    [Ignore]
    public string LipidiosPorcentagem { get; set; }
    public DateTime Data { get; set; }
        
    // [OneToMany]
    // public List<MealModel> ListMeal { get; set; }
}