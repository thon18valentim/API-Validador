using Newtonsoft.Json;

namespace ValidadorAPI
{
  public class Transacao
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("remetente")]
    public int Remetente { get; set; }

    [JsonProperty("recebedor")]
    public int Recebedor { get; set; }

    [JsonProperty("valor")]
    public int Valor { get; set; }

    [JsonProperty("horario")]
    public string Horario { get; set; }

    [JsonProperty("status")]
    public int Status { get; set; }
  }
}
