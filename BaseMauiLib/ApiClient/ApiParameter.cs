namespace MauiLib1.ApiClient;

public class ApiParameter
{
    public const string ClientId = "agriq-clientapp";
    public const string ClientSecret = "Agriq";
        
    public const string NomeCofre = "Agriq-Receitas";
        
    public static readonly string AssineiClientId="assinei-clientapp";
    public static readonly string Scopes = "aliare-backoffice openid profile";
    public static readonly string AssineiClientSecret = "AgriQ";

    //public static readonly string UrlLocal = $"{new EnvironmentParameter().DefaultUrlNotificationHub}/api/DeviceToken";
    public static readonly string UrlLocal = $"troca";
    public static readonly string TenantEnganharia = "fafca64f-a53b-478e-90b2-98f0e8e95cac";
    public static readonly string Product = "agriqMobile";

    public static readonly string ElasticParameterUrl ="https://databriks:IRjl3iBJ9hVaYm5Rne@51fea64441bf4307801053ed49a05181.us-central1.gcp.cloud.es.io";
    public static readonly string ElasticIndex = "rastreamento-production-agriq-mobile";
        
    public static readonly string _nomeCofre = "Agriq-Receitas";
    public static readonly Guid OfertaAgriq = Guid.Parse("a91ca91c-a91c-a91c-a91c-a91ca91ca91c");
    public static readonly string AssinaturaFepWeb = "Assinatura - FepWeb";
    public static readonly string AssinaturaAssinei = "Assinatura Digital";
}