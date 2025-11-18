using CFP.Entities;

namespace CFP.Models
{
    public class ControlePessoalViewModel
    {
        public decimal ValoresMensais { get; set; }
        public decimal Salario { get; set; }
        public decimal Sobras { get; set; }
        public List<Despesa> Despesas { get; set; } = new List<Despesa>();
        public string? mes { get; set; }
    }
}
