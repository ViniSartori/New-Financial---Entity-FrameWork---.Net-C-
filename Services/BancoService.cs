using Financeiro.Domain;
using Financeiro.Repository;
using Financeiro.Services;

namespace Financeiro.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _repository;

        public BancoService(IBancoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Banco>> ListarBancosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Banco?> BuscarBancoAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }


        public async Task CadastrarBancoAsync(Banco banco)
        {
            if (string.IsNullOrEmpty(banco.Nome))
                throw new ArgumentException("O nome do Banco é obrigatório");

            await _repository.AddAsync(banco);
        }


        public async Task AtualizarBancoAsync(Banco banco)
        {
            await _repository.UpdateAsync(banco);
        }


        public async Task ExcluirBancoAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
