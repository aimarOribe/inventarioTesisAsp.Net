using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Collections;

namespace CapaDatos
{
    public class cdUsuario
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT U.IDUSUARIO,U.DOCUMENTO,U.NOMBRECOMPLETO,U.CORREO,U.CLAVE,U.ESTADO, R.IDROL, R.DESCRIPCION FROM USUARIO U");
                    query.AppendLine("INNER JOIN ROL R");
                    query.AppendLine("ON U.IDROL = R.IDROL");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IDUSUARIO = Convert.ToInt32(reader["IDUSUARIO"]),
                                DOCUMENTO = reader["DOCUMENTO"].ToString(),
                                NOMBRECOMPLETO = reader["NOMBRECOMPLETO"].ToString(),
                                CORREO = reader["CORREO"].ToString(),
                                CLAVE = reader["CLAVE"].ToString(),
                                ESTADO = Convert.ToBoolean(reader["ESTADO"]),
                                oROL = new Rol { IDROL = Convert.ToInt32(reader["IDROL"]), DESCRIPCION = reader["DESCRIPCION"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        public int RegistrarUsuario(Usuario usuario, out string Mensaje)
        {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", conexion);
                    cmd.Parameters.AddWithValue("@DOCUMENTO",usuario.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", usuario.NOMBRECOMPLETO);
                    cmd.Parameters.AddWithValue("@CORREO", usuario.CORREO);
                    cmd.Parameters.AddWithValue("@CLAVE", usuario.CLAVE);
                    cmd.Parameters.AddWithValue("@IDROL", usuario.oROL.IDROL);
                    cmd.Parameters.AddWithValue("@ESTADO", usuario.ESTADO);
                    cmd.Parameters.Add("@IDUSUARIORESULTADO",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["@IDUSUARIORESULTADO"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                idUsuarioGenerado = 0;
                Mensaje = e.Message;
            }

            return idUsuarioGenerado;
        }

        public bool EditarUsuario(Usuario usuario, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", conexion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", usuario.IDUSUARIO);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", usuario.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", usuario.NOMBRECOMPLETO);
                    cmd.Parameters.AddWithValue("@CORREO", usuario.CORREO);
                    cmd.Parameters.AddWithValue("@CLAVE", usuario.CLAVE);
                    cmd.Parameters.AddWithValue("@IDROL", usuario.oROL.IDROL);
                    cmd.Parameters.AddWithValue("@ESTADO", usuario.ESTADO);
                    cmd.Parameters.Add("@RESPUESTA", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["@RESPUESTA"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                respuesta = false;
                Mensaje = e.Message;
            }

            return respuesta;
        }

        public bool EliminarUsuario(Usuario usuario, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", conexion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", usuario.IDUSUARIO);
                    cmd.Parameters.Add("@RESPUESTA", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["@RESPUESTA"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                respuesta = false;
                Mensaje = e.Message;
            }

            return respuesta;
        }
    }
}
