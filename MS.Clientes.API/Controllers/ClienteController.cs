using Microsoft.AspNetCore.Mvc;
using MS.Commerce.Entidad;
using MS.Commerce.Negocio;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            return ClienteNegocio.SelCliente(
                new Cliente()
                {
                    Id = id
                }).FirstOrDefault();
        }

        [HttpPost]
        public ActionResult<Cliente> Crear(Cliente cliente)
        {
            var rptCliente = ClienteNegocio.InsCliente(cliente);
            //return CreatedAtAction("GetCliente", new { id = rptCliente.Id }, rptCliente );
            return rptCliente;
        }
    }
}
