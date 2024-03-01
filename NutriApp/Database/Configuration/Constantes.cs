namespace NutriApp.AppNutri.BancoDados.Config;

public class Constantes
{
    public const string NomeDoArquivo = "nutridb.db3";

    public static string CaminhoDoBanco()
    {
        return Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), NomeDoArquivo);
    }
}