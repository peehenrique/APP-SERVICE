namespace Service.Helpers;

public class AppSettings
{
    public string Secret { get; set; } = null!;
    public int LoginTokenExpirationHour { get; set; } = default!;
}
