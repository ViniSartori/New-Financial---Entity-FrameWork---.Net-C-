using Financeiro.Domain;
using static Financeiro.Domain.Lancamento;

namespace Financeiro.Repository
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> GetAllAsync();
        Task<Lancamento?> GetByFilterAsync(LancamentoFiltro filtro);
        Task AddAsync(Lancamento lancamento);
        Task UpdateAsync(Lancamento lancamento);
        Task DeleteAsync(int id);
        Task<decimal> GetSaldoAsync();
    }

}
