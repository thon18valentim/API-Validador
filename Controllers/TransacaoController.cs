using Microsoft.AspNetCore.Mvc;
using ValidadorAPI.infra.api;
using ValidadorAPI.utils;

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

        // Obtendo horário do gerenciador 
        var horario = "";
        var horarioFormatado = 0f;
        var horarioRequisicao = 0f;
        var horarioRecebimento = 0f;
        try
        {
          DateTime timeNow = DateTime.Now;
          horarioRequisicao = ((DateTimeOffset)timeNow).ToUnixTimeSeconds();

          horario = await gerenciadorIntegracao.ObterHorarioGerenciador();
          timeNow = DateTime.Now;
          horarioRecebimento = ((DateTimeOffset)timeNow).ToUnixTimeSeconds();

          horarioFormatado = float.Parse(horario);
        }
        catch
        {
          Console.WriteLine("Nao conseguiu obter horario do gerenciador");
          return Ok(2);
        }

        // Sincronizando tempo
        var tempo = SyncTime.CristianSyncTime(horarioFormatado, horarioRequisicao, horarioRecebimento);

        // Obtendo informações do cliente
        Cliente cliente = await gerenciadorIntegracao.ObterCliente(transacao.Remetente);

        // Verificando saldo do cliente
        if(transacao.Valor > cliente.QtdMoeda)
        {
          Console.WriteLine("Cliente com saldo insuficiente");
          return Ok(2);
        }

        // Verificando valor temporal
        DateTime foo = DateTime.Now;
        var horarioSistema = ((DateTimeOffset)foo).ToUnixTimeSeconds();
        var horarioTransacao = float.Parse(transacao.Horario);

        if (horarioSistema > horarioTransacao)
        {
          Console.WriteLine("Horario da transacao e invalido");
          return Ok(2);
        }

        // Enviar chave unica
        if(await gerenciadorIntegracao.CompararChaves() == 2)
        {
          Console.WriteLine("Chave do validador e invalida");
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
