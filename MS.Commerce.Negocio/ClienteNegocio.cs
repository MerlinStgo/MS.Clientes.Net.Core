﻿using MS.Commerce.Datos;
using MS.Commerce.Entidad;
using System;
using System.Collections.Generic;

namespace MS.Commerce.Negocio
{
    public class ClienteNegocio
    {
        public static Cliente InsProducto(Cliente cliente)
        {
            try
            {
                return new ClienteDatos().InsCliente(cliente);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Cliente> SelCliente(Cliente cliente)
        {
            try
            {
                return new ClienteDatos().SelCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}