using Dapper;
using MS.Commerce.Entidad;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MS.Commerce.Datos
{
   public class ClienteDatos
    {
        private readonly ConnectionFactory _conexionFactory;

        public ClienteDatos()
        {
            _conexionFactory = new ConnectionFactory();
        }

        public Cliente InsCliente(Cliente cliente)
        {
            const string sql = "SP_I_Cliente";

            using (var con = _conexionFactory.ObtenerConexionMS)
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Nombres", cliente.Nombres, DbType.String);
                parametros.Add("@Apellidos", cliente.Apellidos, DbType.String);
                parametros.Add("@Direccion", cliente.Direccion, DbType.String);
                parametros.Add("@Telefono", cliente.Telefono, DbType.String);
                parametros.Add("@Estado", cliente.Estado, DbType.Boolean);

                cliente.Id = con.Query<int>(sql, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cliente;
        }

        public List<Cliente> SelCliente(Cliente cliente)
        {
            const string sql = "SP_S_Cliente_Id";

            using var con = _conexionFactory.ObtenerConexionMS;
            var parametros = new DynamicParameters();
            parametros.Add("@Id", cliente.Id, DbType.String);

            return con.Query<Cliente>(sql, parametros, commandType: CommandType.StoredProcedure).ToList();

        }
    }
}
