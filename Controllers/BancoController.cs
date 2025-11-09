using Microsoft.AspNetCore.Mvc;
using Financeiro.Domain;
using Microsoft.AspNetCore.Identity;
using Financeiro.Services;


namespace Financeiro.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("ConsultarBancos")]
        public async Task<IActionResult> GetAll()
        {
            var bancos = await _bancoService.ListarBancosAsync();
            return Ok(bancos);
        }

        [HttpGet("ConsultarBancosID")]
        public async Task<IActionResult> GetById(int id)
        {
            var banco = await _bancoService.BuscarBancoAsync(id);
            if (banco == null)
                return NotFound();
            return Ok(banco);
        }

        [HttpPost("AdicionarBanco")]
        public async Task<IActionResult> Create(Banco banco)
        {
            await _bancoService.CadastrarBancoAsync(banco);
            return Ok(banco);
        }

        [HttpPut("AtualizarBancoID")]
        public async Task<IActionResult> Update(int id, Banco banco)
        {
            if (id != banco.Id)
                return BadRequest();

            await _bancoService.AtualizarBancoAsync(banco);
            return NoContent();
        }

        [HttpDelete("DeletarBancoID")]   
        public async Task<IActionResult> Delete(int id)
        {
            await _bancoService.ExcluirBancoAsync(id);
            return NoContent();
        }

    }
}
