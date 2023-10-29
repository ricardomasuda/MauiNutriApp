namespace NutriApp.AppNutri.Model;

public class PatientModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Age { get; set; }
    public double Weigh { get; set; }
    public double Wrist { get; set; }
    public double Height { get; set; }
    public double Femur { get; set; }
    public DateTime DataNacimento { get; set; }
    public Genders Gender { get; set; }
    //[OneToMany]
    public List<AvaliacaoNutricionalModel> AvaliacaoNutricional { get; set; }
}