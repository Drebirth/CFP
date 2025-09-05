using CFP.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Controllers
{
    public class ContasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Conta conta)
        {
            if (ModelState.IsValid)
            {
                // Lógica para salvar a conta no banco de dados
                return RedirectToAction("Index");
            }
            return View(conta);
        }

       
    }
}
