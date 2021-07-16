using Microsoft.AspNetCore.Mvc;
using MS.Commerce.Entidad;
using MS.Commerce.Negocio;
using System.Collections.Generic;

namespace MS.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return ClienteNegocio.SelCliente(new Cliente());
        }
    }
}
