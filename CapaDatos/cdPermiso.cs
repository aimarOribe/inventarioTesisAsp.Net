using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDatos
{
    public class cdPermiso
    {
        public List<Permiso> ListarPermisos(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.IDROL, P.NOMBREMENU FROM PERMISO P INNER JOIN ROL R");
                    query.AppendLine("ON P.IDROL = R.IDROL");
                    query.AppendLine("INNER JOIN USUARIO U");
                    query.AppendLine("ON U.IDROL = R.IDROL");
                    query.AppendLine("WHERE U.IDUSUARIO = @idUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Permiso
                            {
                                oROL = new Rol { IDROL = Convert.ToInt32(reader["IDROL"])},
                                NOMBREMENU = reader["NOMBREMENU"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }

        public List<Permiso> ListarPermisosAdministrador()
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDROL,NOMBREMENU FROM PERMISO WHERE IDROL = 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Permiso
                            {
                                oROL = new Rol { IDROL = Convert.ToInt32(reader["IDROL"]) },
                                NOMBREMENU = reader["NOMBREMENU"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }

        public List<Permiso> ListarPermisosEmpleado()
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDROL,NOMBREMENU FROM PERMISO WHERE IDROL = 2");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Permiso
                            {
                                oROL = new Rol { IDROL = Convert.ToInt32(reader["IDROL"]) },
                                NOMBREMENU = reader["NOMBREMENU"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }

        public int RegistrarPermiso(Permiso permiso)
        {
            int idCategoriaGenerada = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPERMISO", conexion);
                    cmd.Parameters.AddWithValue("@IDROL", permiso.oROL.IDROL);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", permiso.NOMBREMENU);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idCategoriaGenerada = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                }
            }
            catch (Exception e)
            {
                idCategoriaGenerada = 0;
            }

            return idCategoriaGenerada;
        }

        public int EliminarPermiso(Permiso permiso)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPERMISO", conexion);
                    cmd.Parameters.AddWithValue("@IDROL", permiso.oROL.IDROL);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", permiso.NOMBREMENU);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                }
            }
            catch (Exception e)
            {
                resultado = 0;
            }

            return resultado;
        }
    }
}
