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
    public class cdProveedor
    {
        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IDPROVEEDOR,DOCUMENTO,RAZONSOCIAL,CORREO,TELEFONO,ESTADO FROM PROVEEDOR");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Proveedor
                            {
                                IDPROVEEDOR = Convert.ToInt32(reader["IDPROVEEDOR"]),
                                DOCUMENTO = reader["DOCUMENTO"].ToString(),
                                RAZONSOCIAL = reader["RAZONSOCIAL"].ToString(),
                                CORREO = reader["CORREO"].ToString(),
                                TELEFONO = reader["TELEFONO"].ToString(),
                                ESTADO = Convert.ToBoolean(reader["ESTADO"]),
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }

        public int RegistrarProveedor(Proveedor proveedor, out string Mensaje)
        {
            int idProveedorGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARPROVEEDOR", conexion);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", proveedor.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", proveedor.RAZONSOCIAL);
                    cmd.Parameters.AddWithValue("@CORREO", proveedor.CORREO);
                    cmd.Parameters.AddWithValue("@TELEFONO", proveedor.TELEFONO);
                    cmd.Parameters.AddWithValue("@ESTADO", proveedor.ESTADO);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idProveedorGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                idProveedorGenerado = 0;
                Mensaje = e.Message;
            }

            return idProveedorGenerado;
        }

        public bool EditarProveedor(Proveedor proveedor, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_MODIFICARPROVEEDOR", conexion);
                    cmd.Parameters.AddWithValue("@IDPROVEEDOR", proveedor.IDPROVEEDOR);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", proveedor.DOCUMENTO);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", proveedor.RAZONSOCIAL);
                    cmd.Parameters.AddWithValue("@CORREO", proveedor.CORREO);
                    cmd.Parameters.AddWithValue("@TELEFONO", proveedor.TELEFONO);
                    cmd.Parameters.AddWithValue("@ESTADO", proveedor.ESTADO);
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

        public bool EliminarProveedor(Proveedor proveedor, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINARPROVEEDOR", conexion);
                    cmd.Parameters.AddWithValue("@IDPROVEEDOR", proveedor.IDPROVEEDOR);
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
    }
}
