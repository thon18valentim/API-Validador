using Newtonsoft.Json;

namespace ValidadorAPI.domain
{
  public class Chave
  {
    [JsonProperty("chaveUnica")]
    public string ChaveUnica { get; set; }
  }
}
