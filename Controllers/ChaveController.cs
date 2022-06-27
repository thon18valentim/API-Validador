using Microsoft.AspNetCore.Mvc;
using ValidadorAPI.domain;
using System.IO;

namespace ValidadorAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ChaveController: ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult> ReceberChave(Chave chave)
    {
      try
      {
        // salvar chave
        System.IO.File.WriteAllText("ChaveUnica.txt", chave.ChaveUnica);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
