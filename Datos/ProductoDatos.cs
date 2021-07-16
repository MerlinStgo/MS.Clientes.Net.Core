using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MS.Commerce.Entidad;

namespace MS.Commerce.Datos
{
    public class ProductoDatos
    {
        private readonly ConnectionFactory _conexionFactory;

        public ProductoDatos()
        {
            _conexionFactory = new ConnectionFactory();
        }

        public Producto InsProducto(Producto producto)
        {
            const string sql = "SP_I_Producto";

            using (var con = _conexionFactory.ObtenerConexionMS)
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@Imagen", producto.Imagen, DbType.String);
                parametros.Add("@PrecioUnitario", producto.PrecioUnitario, DbType.Decimal);
                parametros.Add("@Estado", producto.Estado, DbType.Boolean);
                parametros.Add("@FechaVencimiento", producto.FechaVencimiento, DbType.DateTime);

                producto.IdProducto = con.Query<int>(sql, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return producto;
        }

        public List<Producto> SelProducto(Producto producto)
        {
            const string sql = "SP_S_Producto_IdProducto";

            using var con = _conexionFactory.ObtenerConexionMS;
            var parametros = new DynamicParameters();
            parametros.Add("@IdProducto", producto.IdProducto, DbType.Int32);

            return con.Query<Producto>(sql, parametros, commandType: CommandType.StoredProcedure).ToList();

        }
    }
}
