using Microsoft.AspNetCore.Mvc;
using ValidadorAPI.infra.api;

namespace ValidadorAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TransacaoController: ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult<int>> ReceberTransacao(Transacao transacao)
    {
      try
      {
        // Iniciando validações
        GerenciadorIntegracao gerenciadorIntegracao = new();

        Cliente cliente = await gerenciadorIntegracao.ObterCliente(transacao.Remetente);

        // Verificando saldo do cliente
        if(transacao.Valor > cliente.QtdMoeda)
        {
          return Ok(2);
        }

        // Verificando valor temporal
        DateTime foo = DateTime.Now;
        var horarioSitema = ((DateTimeOffset)foo).ToUnixTimeSeconds();
        var horarioTransacao = float.Parse(transacao.Horario);

        if(horarioTransacao > horarioSitema)
        {
          return Ok(2);
        }

        // Enviar chave unica
        if(await gerenciadorIntegracao.CompararChaves() == 2)
        {
          return Ok(2);
        }

        return Ok(1);
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
