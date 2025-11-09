using Financeiro.Domain;
using Financeiro.Data;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Repository
{
    public class BancoRepository : IBancoRepository
    {

        private readonly FinanceiroContext _context;

        public BancoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Banco>> GetAllAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco?> GetByIdAsync(int id)
        {
            return await _context.Bancos.FindAsync(id);
        }

        public async Task AddAsync(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Banco banco)
        {
            _context.Bancos.Update(banco);
            await _context.SaveChangesAsync();
        }
                
        public async Task DeleteAsync(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco != null)
            {
                _context.Bancos.Remove(banco);
                await _context.SaveChangesAsync();
            }
        }
    }
}
