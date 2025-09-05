namespace CFP.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public decimal? TotalizadorDespesas { get; set; }
        public decimal? TotalizadorSalario { get; set; }
        public List<Despesas>? Despesas { get; set; }
    }
}
