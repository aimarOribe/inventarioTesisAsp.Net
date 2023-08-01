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
    public class cdNegocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio negocio = new Negocio();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SELECT IDNEGOCIO,NOMBRE,RUC,DIRECCION FROM NEGOCIO WHERE IDNEGOCIO = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            negocio = new Negocio
                            {
                                IDNEGOCIO = int.Parse(dr["IDNEGOCIO"].ToString()),
                                NOMBRE = dr["NOMBRE"].ToString(),
                                RUC = dr["RUC"].ToString(),
                                DIRECCION = dr["DIRECCION"].ToString()
                            };
                        }
                    }

                }
            }
            catch
            {
                negocio = new Negocio();
            }

            return negocio;
        }

        public bool GuardarDatos(Negocio negocio, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET NOMBRE = @NOMBRE, RUC = @RUC, DIRECCION = @DIRECCION");
                    query.AppendLine("WHERE IDNEGOCIO = 1");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@NOMBRE", negocio.NOMBRE);
                    cmd.Parameters.AddWithValue("@RUC", negocio.RUC);
                    cmd.Parameters.AddWithValue("@DIRECCION", negocio.DIRECCION);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se logro guardar los datos";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public byte[] RecuperarLogo(out bool respuesta)
        {
            respuesta = true;
            byte[] logoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "SELECT LOGO FROM NEGOCIO WHERE IDNEGOCIO = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            logoBytes = (byte[])dr["LOGO"];
                        };
                    }
                }
            }
            catch
            {
                respuesta = false;
                logoBytes = new byte[0];
            }

            return logoBytes;
        }

        public bool actualizarLogo(byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET LOGO = @IMAGEN");
                    query.AppendLine("WHERE IDNEGOCIO = 1");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IMAGEN", imagen);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se logro actualizar el nuevo logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
