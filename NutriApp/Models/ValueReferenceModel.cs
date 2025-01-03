using NutriApp.Database.Configuration;
using SQLite;

namespace NutriApp.Models;

public class ValueReferenceModel : IEntityAuditableBase<int>
{
    [PrimaryKey,AutoIncrement]
    public int Id { get; set; }
    public int FoodPlanId { get; set; }
    public double Peso { get; set; }
    public double Energia { get; set; }
    public int Carboidratos { get; set; }
    public int Proteinas { get; set; }
    public int Lipidios { get; set; }
    
    public bool Active { get; set; }
    public string ReturnMessage { get; set; }
    public bool Visible { get; set; }
    public DateTimeOffset? LastSync { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
}