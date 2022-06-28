namespace ValidadorAPI.config
{
  public class GerenciadorConfiguracao
  {
    public string? UrlBase { get; set; }
    public string? Cliente { get; set; }
    public string? Chave { get; set; }
    public string? Horario { get; set; }
  }

  public static class BuildGerenciadorConfiguracao
  {
    public static GerenciadorConfiguracao Build()
    {
      IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      return config.GetRequiredSection("GerenciadorUrl").Get<GerenciadorConfiguracao>();
    }
  }
}
