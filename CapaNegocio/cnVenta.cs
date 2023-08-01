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
    public class cnVenta
    {
        private cdVenta ocdVenta = new cdVenta();

        public bool RestarStock(int IdProducto, int Cantidad)
        {
            return ocdVenta.RestarStock(IdProducto, Cantidad);
        }

        public bool SumarStock(int IdProducto, int Cantidad)
        {
            return ocdVenta.SumarStock(IdProducto, Cantidad);
        }

        public int ObtenerIdIncrementable()
        {
            return ocdVenta.ObtenerIdIncrementable();
        }

        public bool RegistrarVenta(Venta venta, DataTable dtDetalleVenta, out string Mensaje)
        {
            return ocdVenta.RegistrarVenta(venta, dtDetalleVenta, out Mensaje);
        }

        public Venta ObtenerVenta(string numeroDocumento)
        {
            Venta venta = ocdVenta.ObtenerVenta(numeroDocumento);

            if(venta.IDVENTA != 0)
            {
                List<DetalleVenta> detalleVenta = ocdVenta.ObtenerDetallesVentas(venta.IDVENTA);
                venta.oDETALLEVENTA = detalleVenta;
            }

            return venta;
        }
    }
}
