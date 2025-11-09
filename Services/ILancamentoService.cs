using Financeiro.Domain;
using static Financeiro.Domain.Lancamento;


namespace Financeiro.Services
{
    public interface ILancamentoService
    {
        Task<IEnumerable<Lancamento>> ListarLancamentosAsync();
        Task<Lancamento?> BuscarLancamentoAsync(LancamentoFiltro filtro);
        Task CadastrarLancamentoAsync(Lancamento lancamento);
        Task AtualizarLancamentoAsync(Lancamento lancamento);
        Task ExcluirLancamento(int id);
        Task<decimal> ObterSaldoAsync();
    }
}
