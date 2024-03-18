namespace MauiLib1.User;

public class UserPreferenceUserInfo
{
    public string AuthToken { get; set; }
    public string RefreshToken { get; set; }
    public Guid TenantId { get; set; }
    public string UserId { get; set; }
    public string PessoaId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PictureUrl { get; set; }
    public string CofreId { get; set; }
    public bool UseBiometry { get; set; }
    public string Documento { get; set; }
    public int UnidadeRecebimentoPadrao { get; set; }
    public DateTimeOffset Login { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset Expire { get; set; }
    public bool AssinaturaFepWeb { get; set; }
    public bool AssinaturaAssinei { get; set; }
}