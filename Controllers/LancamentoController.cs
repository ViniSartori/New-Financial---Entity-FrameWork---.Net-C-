using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Financeiro.Services;
using Financeiro.Domain;
using static Financeiro.Domain.Lancamento;

namespace Financeiro.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpGet("ConsultarLancamentos")]
        public async Task<IActionResult> GetAll()
        {
            var lancamentos = await _lancamentoService.ListarLancamentosAsync();
            return Ok(lancamentos);
        }

        [HttpGet("ConsultarLancamentosDataouId")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] LancamentoFiltro filtro)
        {
            var lancamentos = await _lancamentoService.BuscarLancamentoAsync(filtro);
            if (lancamentos == null)
                return NotFound(new { Mensagem = "Nenhum lançamento encontrado com o filtro informado." });
            return Ok(lancamentos);
        }

        [HttpPost("CadastrarLancamentos")]
        public async Task<IActionResult> Create(Lancamento lancamento)
        {
            await _lancamentoService.CadastrarLancamentoAsync(lancamento);
            return CreatedAtAction(nameof(GetByFilterAsync), new { id = lancamento.Id }, lancamento);
        }

        [HttpPut("AlterarLancamento/{id}")]
        public async Task<IActionResult> Update(int id, [FromQuery] Lancamento lancamento)
        {
            if (lancamento == null || lancamento.Id != id)
                return BadRequest(new { Mensagem = "ID do lançamento inválido ou dados ausentes." });

            await _lancamentoService.AtualizarLancamentoAsync(lancamento);
            return NoContent();
        }

        [HttpDelete("DeletarLancamento/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lancamentoService.ExcluirLancamento(id);
            return NoContent();
        }

        [HttpGet("ObterSaldo")]
        public async Task<IActionResult> GetSaldo()
        {
            var saldo = await _lancamentoService.ObterSaldoAsync();
            return Ok(new { SaldoAtual = saldo});
        }
    }
}
