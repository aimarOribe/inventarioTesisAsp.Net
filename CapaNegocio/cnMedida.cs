using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class cnMedida
    {
        private cdMedida ocdMedida = new cdMedida();

        public List<Medida> ListarMedidas()
        {
            return ocdMedida.ListarMedidas();
        }
    }
}
