using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnCompra
    {
        private cdCompra ocdCompra = new cdCompra();

        public int ObtenerIdIncrementable()
        {
            return ocdCompra.ObtenerIdIncrementable();
        }

        public bool RegistrarCompra(Compra compra, DataTable dtDetalleCompra, out string Mensaje)
        {
            return ocdCompra.RegistrarCompra(compra, dtDetalleCompra, out Mensaje);
        }

        public Compra ObtenerCompra(string numeroDocumento)
        {
            Compra compra = ocdCompra.ObtenerCompra(numeroDocumento);
            if(compra.IDCOMPRA != 0)
            {
                List<DetalleCompra> listaDetallesCompras = ocdCompra.ObtenerDetallesCompras(compra.IDCOMPRA);
                compra.oDETALLECOMPRA = listaDetallesCompras;
            }
            return compra;
        }
    }
}
