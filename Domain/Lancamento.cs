namespace Financeiro.Domain
{
    public class Lancamento
    {
        public Lancamento() { }

        public Lancamento(decimal saldoInicial)
        {
            Saldo = saldoInicial;
            Data = DateTime.Now;
        }

        
        public int Id { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public string Historico { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public decimal Saldo { get; set; }

        
        public class LancamentoFiltro
        {
            public int? Id { get; set; }
            public DateTime? Data { get; set; }
        }

        public decimal GetSaldo() => Saldo;

        public void RegistrarMovimento(decimal valor, string historico)
        {
            if (string.IsNullOrWhiteSpace(historico))
                throw new ArgumentException("O histórico não pode ser vazio", nameof(historico));

            Valor = valor;
            Historico = historico;
            Data = DateTime.Now;
            Saldo += valor;
        }
    }
}
