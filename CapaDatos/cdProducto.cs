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
    public class cdProducto
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.IDPRODUCTO,P.CODIGO,P.NOMBRE,P.DESCRIPCION,C.IDCATEGORIA,C.DESCRIPCION AS DESCRIPCIONCATEGORIA,M.DESCRIPCION AS MEDIDA,P.STOK,P.PRECIOCOMPRA,P.PRECIOVENTA,P.IMAGEN,P.ESTADO FROM PRODUCTO P");
                    query.AppendLine("INNER JOIN CATEGORIA C");
                    query.AppendLine("ON P.IDCATEGORIA = C.IDCATEGORIA");
                    query.AppendLine("INNER JOIN MEDIDA M");
                    query.AppendLine("ON C.IDMEDIDA = M.IDMEDIDA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Producto
                            {
                                IDPRODUCTO = Convert.ToInt32(reader["IDPRODUCTO"]),
                                CODIGO = reader["CODIGO"].ToString(),
                                NOMBRE = reader["NOMBRE"].ToString(),
                                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                                oCATEGORIA = new Categoria { IDCATEGORIA = Convert.ToInt32(reader["IDCATEGORIA"]), DESCRIPCION = reader["DESCRIPCIONCATEGORIA"].ToString(), oMEDIDA = new Medida { DESCRIPCION = reader["MEDIDA"].ToString() } },
                                STOCK = Convert.ToInt32(reader["STOK"].ToString()),
                                PRECIOCOMPRA = Convert.ToDecimal(reader["PRECIOCOMPRA"].ToString()),
                                PRECIOVENTA = Convert.ToDecimal(reader["PRECIOVENTA"].ToString()),
                                IMAGEN = reader["IMAGEN"] == DBNull.Value ? Encoding.ASCII.GetBytes(reader["CODIGO"].ToString()) : (byte[])reader["IMAGEN"],
                                ESTADO = Convert.ToBoolean(reader["ESTADO"])
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Producto>();
                }
            }
            return lista;
        }

        public int RegistrarProducto(Producto producto, out string Mensaje)
        {
            int idProductoGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_REGISTRARPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("@CODIGO", producto.CODIGO);
                    cmd.Parameters.AddWithValue("@NOMBRE", producto.NOMBRE);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", producto.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", producto.oCATEGORIA.IDCATEGORIA);
                    cmd.Parameters.AddWithValue("@IMAGEN", producto.IMAGEN);
                    cmd.Parameters.AddWithValue("@ESTADO", producto.ESTADO);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                idProductoGenerado = 0;
                Mensaje = e.Message;
            }

            return idProductoGenerado;
        }

        public bool EditarProducto(Producto producto, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_EDITARPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("@IDPRODUCTO", producto.IDPRODUCTO);
                    cmd.Parameters.AddWithValue("@CODIGO", producto.CODIGO);
                    cmd.Parameters.AddWithValue("@NOMBRE", producto.NOMBRE);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", producto.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", producto.oCATEGORIA.IDCATEGORIA);
                    cmd.Parameters.AddWithValue("@IMAGEN", producto.IMAGEN);
                    cmd.Parameters.AddWithValue("@ESTADO", producto.ESTADO);
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

        public bool EliminarProducto(Producto producto, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_ELIMINARPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("@IDPRODUCTO", producto.IDPRODUCTO);
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
