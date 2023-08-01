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
    public class cdCliente
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDCLIENTE,DOCUMENTO,NOMBRECOMPLETO,CORREO,TELEFONO,ESTADO FROM CLIENTE");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cliente
                            {
                                IDCLIENTE = Convert.ToInt32(reader["IDCLIENTE"]),
                                DOCUMENTO = reader["DOCUMENTO"].ToString(),
                                NOMBRECOMPLETO = reader["NOMBRECOMPLETO"].ToString(),
                                CORREO = reader["CORREO"].ToString(),
                                TELEFONO = reader["TELEFONO"].ToString(),
                                ESTADO = Convert.ToBoolean(reader["ESTADO"]),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        public int RegistrarCliente(Cliente cliente, out string Mensaje)
        {
            int idClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCLIENTE", conexion);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", cliente.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", cliente.NOMBRECOMPLETO);
                    cmd.Parameters.AddWithValue("@CORREO", cliente.CORREO);
                    cmd.Parameters.AddWithValue("@TELEFONO", cliente.TELEFONO);
                    cmd.Parameters.AddWithValue("@ESTADO", cliente.ESTADO);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idClienteGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                idClienteGenerado = 0;
                Mensaje = e.Message;
            }

            return idClienteGenerado;
        }

        public bool EditarCliente(Cliente cliente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARCLIENTE", conexion);
                    cmd.Parameters.AddWithValue("@IDCLIENTE", cliente.IDCLIENTE);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", cliente.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", cliente.NOMBRECOMPLETO);
                    cmd.Parameters.AddWithValue("@CORREO", cliente.CORREO);
                    cmd.Parameters.AddWithValue("@TELEFONO", cliente.TELEFONO);
                    cmd.Parameters.AddWithValue("@ESTADO", cliente.ESTADO);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["@RESULTADO"].Value);
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

        public bool EliminarCliente(Cliente cliente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE", conexion);
                    cmd.Parameters.AddWithValue("@IDCLIENTE", cliente.IDCLIENTE);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
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
