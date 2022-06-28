using RestSharp;
using ValidadorAPI.config;
using Newtonsoft.Json;

namespace ValidadorAPI.infra.api
{
  public class GerenciadorIntegracao
  {
    private RestClient restClient;
    private GerenciadorConfiguracao gerenciadorConfiguracao;

    public GerenciadorIntegracao()
    {
      gerenciadorConfiguracao = BuildGerenciadorConfiguracao.Build();
    }

    public async Task<Cliente> ObterCliente(int id)
    {
      try
      {
        restClient = new();
        var request = new RestRequest($"{gerenciadorConfiguracao.UrlBase}{gerenciadorConfiguracao.Cliente}/{id}")
        {
          Method = Method.Get
        };

        var response = await restClient.GetAsync(request);
        var retorno = response.Content;

        Cliente cliente = JsonConvert.DeserializeObject<Cliente>(retorno) ?? new Cliente();

        return cliente;
      }
      catch
      {
        throw;
      }
    }

    public async Task<string> ObterHorarioGerenciador()
    {
      try
      {
        restClient = new();
        var request = new RestRequest($"{gerenciadorConfiguracao.UrlBase}{gerenciadorConfiguracao.Horario}")
        {
          Method= Method.Get
        };

        var response = await restClient.GetAsync(request);
        var retorno = response.Content ?? "";

        return retorno;
      }
      catch
      {
        throw;
      }
    }

    public async Task<int> CompararChaves()
    {
      try
      {
        var chave = File.ReadAllText("ChaveUnica.txt");
        string url = $"https://127.0.0.1:7127/Validador/chave/{chave}";

        var options = new RestClientOptions(url)
        {
          RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
        };

        restClient = new(options);
        var request = new RestRequest()
        {
          Resource = url,
          Method = Method.Get
        };

        var response = await restClient.GetAsync(request);
        var retorno = response.Content;

        var num = int.Parse(retorno);
        return num;
      }
      catch
      {
        throw;
      }
    }
  }
}
