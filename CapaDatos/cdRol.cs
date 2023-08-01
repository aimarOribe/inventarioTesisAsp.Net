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
    public class cdRol
    {
        public List<Rol> ListarRoles()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDROL,DESCRIPCION FROM ROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Rol
                            {
                                IDROL = Convert.ToInt32(reader["IDROL"]),
                                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}
