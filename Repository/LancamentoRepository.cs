using Financeiro.Domain;
using Financeiro.Data;
using Microsoft.EntityFrameworkCore;
using static Financeiro.Domain.Lancamento;


namespace Financeiro.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly FinanceiroContext _context;

        public LancamentoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento?> GetByFilterAsync(LancamentoFiltro filtro)
        {
            var query = _context.Lancamentos.AsQueryable();

            if (filtro.Id.HasValue)
                query = query.Where(l => l.Id == filtro.Id.Value);

            if (filtro.Data.HasValue)
                query = query.Where(l => l.Data == filtro.Data.Value);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento != null)
            {
                _context.Lancamentos.Remove(lancamento);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<decimal> GetSaldoAsync()
        {
            var saldo = await _context.Lancamentos.SumAsync(l => (decimal?)l.Valor) ?? 0;
            return saldo;
        }
     }
}
