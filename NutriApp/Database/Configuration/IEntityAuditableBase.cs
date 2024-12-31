namespace NutriApp.Database.Configuration;

public interface IEntityAuditableBase<T>
{
    T Id { get; set; }
    bool Active { get; set; }
    string ReturnMessage { get; set; }
    bool Visible { get; set; }
    DateTimeOffset? LastSync { get; set; }
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset? LastUpdatedAt { get; set; }
}