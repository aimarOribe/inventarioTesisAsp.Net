using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class cdMedida
    {
        public List<Medida> ListarMedidas()
        {
            List<Medida> lista = new List<Medida>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDMEDIDA,DESCRIPCION FROM MEDIDA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Medida
                            {
                                IDMEDIDA = Convert.ToInt32(reader["IDMEDIDA"]),
                                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Medida>();
                }
            }
            return lista;
        }
    }
}
