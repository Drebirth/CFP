using CFP.Entities;

namespace CFP.Models
{
    public class DespesasViewModel
    {
        public string? NomeDespesa { get; set; }
        public Categorias? Categoria { get; set; }
       // public List<Categorias>? Categorias { get; set; } = new List<Categorias>();
        public decimal? Valor { get; set; }
        public DateTime? DataDespesa { get; set; }
    }
}
