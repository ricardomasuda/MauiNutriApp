using NutriApp.Database.Configuration;
using SQLite;

namespace NutriApp.Models;

public class MealFoodModel : IEntityAuditableBase<int>
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public int FoodId { get; set; }
    public double Medida { get; set; }
    public int MealId { get; set; }
    
    public bool Active { get; set; }
    public string ReturnMessage { get; set; }
    public bool Visible { get; set; }
    public DateTimeOffset? LastSync { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
}