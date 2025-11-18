using Microsoft.AspNetCore.Mvc.Rendering;

namespace CFP.Entities
{
    public class Despesa
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? Nome_Despesa { get; set; }
        public Categorias? Categoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data_Despesa { get; set; }
        public DateTime Data_inclusao { get; set; } = DateTime.Now;
 //       public List<SelectListItem> CategoriasList { get; internal set; }
    }
}
