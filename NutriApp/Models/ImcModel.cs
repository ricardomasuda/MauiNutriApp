namespace NutriApp.AppNutri.Model;

public class ImcModel
{
    public string Peso { get; set; }
    public string Altura { get; set; }
    public double Resultado { get; set; }
    public string PesoIdeal { get; set; }
    public string PesoAtual { get; set; }
}
    
public class ImcClassificacao
{
    public string Imc { get; set; }
    public string Classificacao { get; set; }
}
    
public class AdequacaoPeso
{
    public string ValorEncontrado { get; set; }
    public string Classificacao { get; set; }
}
    
public enum PersonAgeType
{
    Adulto,
    Idoso
}