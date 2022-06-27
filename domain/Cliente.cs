using Newtonsoft.Json;

namespace ValidadorAPI
{
  public class Cliente
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("qtdMoeda")]
    public int QtdMoeda { get; set; }
  }
}
