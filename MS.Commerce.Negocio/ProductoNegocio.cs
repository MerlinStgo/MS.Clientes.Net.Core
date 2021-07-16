using MS.Commerce.Datos;
using MS.Commerce.Entidad;
using System;
using System.Collections.Generic;

namespace MS.Commerce.Negocio
{
    public static class ProductoNegocio
    {
        public static Producto InsProducto(Producto producto)
        {
            try
            {
                return new ProductoDatos().InsProducto(producto);
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Producto> SelProducto(Producto producto)
        {
            try
            {
                return new ProductoDatos().SelProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
