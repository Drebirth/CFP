using CFP.Context;
using CFP.Entities;
using CFP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CFP.Controllers
{
    [Authorize]
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
            var despesasList = _context.DESPESAS.ToList().Where(d => d.UserName == User.Identity.Name);
            return View(despesasList);
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
                model.UserName = User.Identity.Name ?? "Anônimo";
                _context.DESPESAS.Add(model);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(despesa);
            
            
        }

        // GET: DesepesasController/Edit/5
        public ActionResult Edit(int id)
        {
            var despesa = _context.DESPESAS.Find(id);
            //var despesasViewModel = new DespesasViewModel
            //{
            //    //Id = despesa.Id,
            //    NomeDespesa = despesa.Nome_Despesa,
            //    Categoria = despesa.Categoria,
            //    Valor = despesa.Valor,
            //    DataDespesa = despesa.Data_Despesa,                              
            //};

            var categorias = Enum.GetValues(typeof(Categorias))
                            .Cast<Categorias>()
                            .Select(c => new SelectListItem
                            {
                                Value = ((int)c).ToString(),
                                Text = c.ToString().Replace("_", " ")
                            })
                            .ToList();

            ViewBag.Categorias = categorias;
            return View(despesa);
        }

        // POST: DesepesasController/Edit/5
        [HttpPost]      
        public ActionResult Edit(Despesa despesa)
        {
            if(ModelState.IsValid)
            {
                
                _context.DESPESAS.Update(despesa);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(despesa);
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
            
            var despesas = _context.DESPESAS.Where(d => d.Data_Despesa.Month == mes && d.UserName ==  User.Identity.Name);
            relatorio.Salario = 2800;
            //relatorio.ValoresMensais = (decimal)_context.DESPESAS.Sum(d => d.Valor);
            relatorio.ValoresMensais = despesas.Sum(d => d.Valor);
            relatorio.sobras = relatorio.Salario - (int)relatorio.ValoresMensais;


            ControlePessoalViewModel controlePessoal = new ControlePessoalViewModel();
            controlePessoal.Salario = relatorio.Salario;
            controlePessoal.ValoresMensais = relatorio.ValoresMensais;
            controlePessoal.Sobras = relatorio.sobras;

            //var despesasList = despesas.ToList().Where(d => d.Data_Despesa.Month == DateTime.Now.Month);
            var despesasList = despesas.ToList().Where(d => d.Data_Despesa.Month == mes && d.UserName == User.Identity.Name);
            controlePessoal.Despesas = despesasList.ToList();

            return View(controlePessoal);
        }
    }
}
