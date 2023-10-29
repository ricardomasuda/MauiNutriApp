namespace NutriApp.AppNutri.Model;

public class AvaliacaoNutricionalModel
{
    public int Id { get; set; }
    public DateTime DataAvaliacao { get; set; }
    public string Peso { get; set; }
    public string Altura { get; set; }
        
    public int PatientId { get; set; }
    public PatientModel Patient { get; set; }
}