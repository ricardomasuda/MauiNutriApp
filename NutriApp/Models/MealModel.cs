using SQLite;

namespace NutriApp.Models;

public class MealModel
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public int FoodPLanId { get; set; }
    public string Nome { get; set; }
    public string Horario { get; set; }
    public string Carboidratos { get; set; }
    public string Proteinas { get; set; }
    public string Lipidios { get; set; } 
    public string ValorTotal { get; set; }
    public List<FoodModel> ListFood { get; set; }

    public ObservableCollection<Item> MealType()
    {
        return new ObservableCollection<Item>
        {
            new() {Id = 1, Nome = "Café da manhã"},
            new() {Id = 2, Nome = "Colação"},
            new() {Id = 3, Nome = "Almoço"},
            new() {Id = 4, Nome = "Lanche da Tarde"},
            new() {Id = 5, Nome = "Pré-Treino"},
            new() {Id = 6, Nome = "Pós-Treino"},
            new() {Id = 7, Nome = "Jantar"}
        };
    }

    public Item SearchMealType(string nome)
    {
        return MealType().FirstOrDefault(x => x.Nome == nome);
    }
}