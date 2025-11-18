using System.Linq;
using CFP.Context;
using CFP.Entities;
using CFP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CFP.Controllers
{
    public class DespesasController : Controller
    {
        private readonly ILogger<DespesasController> _logger;
        private readonly AppDbContext _context;

        public DespesasController(ILogger<DespesasController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: DesepesasController
        public ActionResult Index()
        {
            var despesas = _context.DESPESAS.ToList();
            return View(despesas);
        }

        // GET: DesepesasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DesepesasController/Create
        public ActionResult Create()
        {
            var categorias = Enum.GetValues(typeof(Categorias))
                            .Cast<Categorias>()
                            .Select(c => new SelectListItem
                            {
                                Value = ((int)c).ToString(),
                                Text = c.ToString().Replace("_", " ")
                            })
                            .ToList();

            ViewBag.Categorias = categorias;
            return View();

        }

        // POST: DesepesasController/Create
        [HttpPost]
        public ActionResult Create(DespesasViewModel despesa)
        {
            
           if (ModelState.IsValid)
            {
                Despesa model = new Despesa();
                model.Data_inclusao = DateTime.Now;
                model.Nome_Despesa = despesa.NomeDespesa;
                model.Valor = despesa.Valor ?? 0;
                model.Categoria = despesa.Categoria;
                model.Data_Despesa = (DateTime)despesa.DataDespesa;
              
                _context.DESPESAS.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(despesa);
            
            
        }

        // GET: DesepesasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DesepesasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DesepesasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DesepesasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Relatorio(int? mes)
        {
            // Passar o mês como parâmetro futuramente
            ControlePessoal relatorio = new ControlePessoal();
            //var despesas = _context.DESPESAS.Where(d => d.Data_Despesa.Month ==  DateTime.Now.Month);
            var despesas = _context.DESPESAS.Where(d => d.Data_Despesa.Month == mes);
            relatorio.Salario = 2800;
            //relatorio.ValoresMensais = (decimal)_context.DESPESAS.Sum(d => d.Valor);
            relatorio.ValoresMensais = despesas.Sum(d => d.Valor);
            relatorio.sobras = relatorio.Salario - (int)relatorio.ValoresMensais;


            ControlePessoalViewModel controlePessoal = new ControlePessoalViewModel();
            controlePessoal.Salario = relatorio.Salario;
            controlePessoal.ValoresMensais = relatorio.ValoresMensais;
            controlePessoal.Sobras = relatorio.sobras;

            //var despesasList = despesas.ToList().Where(d => d.Data_Despesa.Month == DateTime.Now.Month);
            var despesasList = despesas.ToList().Where(d => d.Data_Despesa.Month == mes);
            controlePessoal.Despesas = despesasList.ToList();

            return View(controlePessoal);
        }
    }
}
