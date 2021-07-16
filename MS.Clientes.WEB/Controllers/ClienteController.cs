using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS.Clientes.WEB.Data;
using MS.Clientes.WEB.Models;
using System.Threading.Tasks;

namespace MS.Clientes.WEB.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Crear(int? id)
        {

            Cliente cliente = new Cliente();

            if(id == null)
            {
                return View(cliente);
            }
            else
            {
                cliente = await _db.Cliente.FindAsync(id);
                return View(cliente);
            }

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {

                if(cliente.Id == 0)
                {
                    await _db.Cliente.AddAsync(cliente);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear));
                }
                else
                {
                    _db.Cliente.Update(cliente);
                    await _db.SaveChangesAsync();

                    return RedirectToAction(nameof(Crear), new { id = 0 });
                }
                
            }
            return View(cliente);
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var todos = await _db.Cliente.ToListAsync();
            return Json(new { data = todos });
        }
    }
}
