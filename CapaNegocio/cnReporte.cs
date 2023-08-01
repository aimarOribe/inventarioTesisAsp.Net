using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnReporte
    {
        private cdReporte ocdReporte = new cdReporte();

        public List<ReporteCompra> ObtenerReporteCompra(string fechaInicio, string fechaFin, int idProveedor)
        {
            return ocdReporte.ObtenerReporteCompra(fechaInicio, fechaFin, idProveedor);
        }

        public List<ReporteVenta> ObtenerReporteVenta(string fechaInicio, string fechaFin)
        {
            return ocdReporte.ObtenerReporteVenta(fechaInicio, fechaFin);
        }
    }
}
