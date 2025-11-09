namespace Financeiro.Domain
{
    public class Banco
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Agencia { get; set; } = string.Empty;

        public string Conta { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

    }
}
