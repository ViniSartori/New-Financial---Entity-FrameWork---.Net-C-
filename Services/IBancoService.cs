using Financeiro.Domain;

namespace Financeiro.Services
{
    public interface IBancoService
    {
        Task<IEnumerable<Banco>> ListarBancosAsync();
        Task<Banco?> BuscarBancoAsync(int id);
        Task CadastrarBancoAsync(Banco banco);
        Task AtualizarBancoAsync(Banco banco);
        Task ExcluirBancoAsync(int id);
    }
}
