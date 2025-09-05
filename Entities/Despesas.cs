namespace CFP.Entities
{
    public class Despesas
    {

        public int Id { get; set; }
       //" public int IdConta { get; set; }
        public Conta? conta { get; set; }
        public string NomeDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataDespesa { get; set; }
        public decimal? TotalizadorDespesasMensal { get; set; }
    }
}
