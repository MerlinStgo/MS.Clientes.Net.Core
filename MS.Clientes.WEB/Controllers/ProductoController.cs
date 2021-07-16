using Microsoft.AspNetCore.Mvc;
using MS.Commerce.Entidad;
using MS.Commerce.Negocio;
using System.Linq;

namespace MS.Clientes.WEB.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var producto = ProductoNegocio.SelProducto(
                        new Producto()
                        {
                            IdProducto = id.Value
                        }
                    ).FirstOrDefault();
                return View(producto);
            }

        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {

            if (ModelState.IsValid)
            {
                producto = ProductoNegocio.InsProducto(producto);
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var todos = ProductoNegocio.SelProducto(new Producto());
            return Json(new { data = todos });
        }

    }
}
