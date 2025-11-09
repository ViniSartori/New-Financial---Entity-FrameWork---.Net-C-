using Financeiro.Domain;

namespace Financeiro.Repository
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllAsync();
        Task<Banco?> GetByIdAsync(int id);
        Task AddAsync(Banco banco);
        Task UpdateAsync(Banco banco);
        Task DeleteAsync(int id);
    }
}
