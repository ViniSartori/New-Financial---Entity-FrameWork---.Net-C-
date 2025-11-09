using Financeiro.Domain;
using Financeiro.Repository;
using Financeiro.Services;
using System.Diagnostics.Eventing.Reader;
using static Financeiro.Domain.Lancamento;

namespace Financeiro.Services
{
    public class LancamentoService : ILancamentoService
     {

        private readonly ILancamentoRepository _repository;

        public LancamentoService(ILancamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Lancamento>> ListarLancamentosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Lancamento?> BuscarLancamentoAsync(LancamentoFiltro filtro)
        {
            return await _repository.GetByFilterAsync(filtro);
        }

        public async Task CadastrarLancamentoAsync(Lancamento lancamento)
        {
            if (string.IsNullOrEmpty(lancamento.Historico))
                throw new ArgumentException("O campo Histórico é obrigatório.");

            if (lancamento.Data == default)
                throw new ArgumentException("A data não pode ser nula.");

            if (lancamento.Valor == 0 || lancamento.Valor == null)
                throw new ArgumentException("O valor não pode ser nulo ou zero.");

            await _repository.AddAsync(lancamento);
        }

        public async Task AtualizarLancamentoAsync(Lancamento lancamento)
        {
            await _repository.UpdateAsync(lancamento);

        }
        
        public async Task ExcluirLancamento(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<decimal> ObterSaldoAsync()
        {
            return await _repository.GetSaldoAsync();
        }
    }
}
