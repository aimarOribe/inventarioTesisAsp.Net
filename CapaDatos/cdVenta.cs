using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Reflection;

namespace CapaDatos
{
    public class cdVenta
    {
        public int ObtenerIdIncrementable()
        {
            int idIncrementable = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM VENTA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    idIncrementable = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    idIncrementable = 0;
                }
            }

            return idIncrementable;
        }

        public bool RestarStock(int IdProducto, int Cantidad)
        {
            bool respuesta = true;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET STOK = STOK - @CANTIDAD WHERE IDPRODUCTO = @IDPRODUCTO");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@CANTIDAD", Cantidad);
                    cmd.Parameters.AddWithValue("@IDPRODUCTO", IdProducto);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception e)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool SumarStock(int IdProducto, int Cantidad)
        {
            bool respuesta = true;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE PRODUCTO SET STOK = STOK + @CANTIDAD WHERE IDPRODUCTO = @IDPRODUCTO");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@CANTIDAD", Cantidad);
                    cmd.Parameters.AddWithValue("@IDPRODUCTO", IdProducto);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception e)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool RegistrarVenta(Venta venta, DataTable dtDetalleVenta, out string mensaje)
        {
            bool Respuesta = false;
            mensaje = string.Empty;
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARVENTA", conexion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", venta.oUSUARIO.IDUSUARIO);
                    cmd.Parameters.AddWithValue("@TIPODOCUMENTO", venta.TIPODOCUMENTO);
                    cmd.Parameters.AddWithValue("@NUMERODOCUMENTO", venta.NUMERODOCUMENTO);
                    cmd.Parameters.AddWithValue("@DOCUMENTOCLIENTE", venta.DOCUMENTOCLIENTE);
                    cmd.Parameters.AddWithValue("@NOMBRECLIENTE", venta.NOMBRECLIENTE);
                    cmd.Parameters.AddWithValue("@MONTOPAGO", venta.MONTOPAGO);
                    cmd.Parameters.AddWithValue("@MONTOCAMBIO", venta.MONTOCAMBIO);
                    cmd.Parameters.AddWithValue("@MONTOTOTAL", venta.MONTOTOTAL);
                    cmd.Parameters.AddWithValue("@DETALLEVENTA", dtDetalleVenta);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["@RESULTADO"].Value);
                    mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
                catch (Exception e)
                {
                    Respuesta = false;
                    mensaje = e.Message;
                }
                return Respuesta;
            }
        }

        public Venta ObtenerVenta(string numeroDocumento)
        {
            Venta venta = new Venta();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT V.IDVENTA,U.NOMBRECOMPLETO,V.DOCUMENTOCLIENTE,V.NOMBRECLIENTE,");
                    query.AppendLine("V.TIPODOCUMENTO,V.NUMERODOCUMENTO,V.MONTOPAGO,V.MONTOCAMBIO,V.MONTOTOTAL,");
                    query.AppendLine("CONVERT(CHAR(10),V.FECHAREGISTRO,103) AS FECHAREGISTRO");
                    query.AppendLine("FROM VENTA V");
                    query.AppendLine("INNER JOIN USUARIO U");
                    query.AppendLine("ON V.IDUSUARIO = U.IDUSUARIO");
                    query.AppendLine("WHERE V.NUMERODOCUMENTO = @NUMERODOCUMENTO");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@NUMERODOCUMENTO", numeroDocumento);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            venta = new Venta
                            {
                                IDVENTA = Convert.ToInt32(reader["IDVENTA"]),
                                oUSUARIO = new Usuario { NOMBRECOMPLETO = reader["NOMBRECOMPLETO"].ToString() },
                                DOCUMENTOCLIENTE = reader["DOCUMENTOCLIENTE"].ToString(),
                                NOMBRECLIENTE = reader["NOMBRECLIENTE"].ToString(),
                                TIPODOCUMENTO = reader["TIPODOCUMENTO"].ToString(),
                                NUMERODOCUMENTO = reader["NUMERODOCUMENTO"].ToString(),
                                MONTOPAGO = Convert.ToDecimal(reader["MONTOPAGO"]),
                                MONTOCAMBIO = Convert.ToDecimal(reader["MONTOCAMBIO"]),
                                MONTOTOTAL = Convert.ToDecimal(reader["MONTOTOTAL"]),
                                FECHAREGISTRO = reader["FECHAREGISTRO"].ToString()
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    venta = new Venta();
                }
            }
            return venta;
        }

        public List<DetalleVenta> ObtenerDetallesVentas(int idVenta)
        {
            List<DetalleVenta> listaDetallesVentas = new List<DetalleVenta>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.NOMBRE,DV.PRECIOVENTA,DV.CANTIDAD,M.DESCRIPCION AS MEDIDA,DV.SUBTOTAL ");
                    query.AppendLine("FROM DETALLEVENTA DV");
                    query.AppendLine("INNER JOIN PRODUCTO P");
                    query.AppendLine("ON DV.IDPRODUCTO = P.IDPRODUCTO");
                    query.AppendLine("INNER JOIN CATEGORIA C");
                    query.AppendLine("ON P.IDCATEGORIA = C.IDCATEGORIA");
                    query.AppendLine("INNER JOIN MEDIDA M");
                    query.AppendLine("ON C.IDMEDIDA = M.IDMEDIDA");
                    query.AppendLine("WHERE DV.IDVENTA = @IDVENTA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IDVENTA", idVenta);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaDetallesVentas.Add(new DetalleVenta
                            {
                                oPRODUCTO = new Producto { NOMBRE = reader["NOMBRE"].ToString(), oCATEGORIA = new Categoria { oMEDIDA = new Medida { DESCRIPCION = reader["MEDIDA"].ToString() } } },
                                PRECIOVENTA = Convert.ToDecimal(reader["PRECIOVENTA"].ToString()),
                                CANTIDAD = Convert.ToInt32(reader["CANTIDAD"].ToString()),
                                SUBTOTAL = Convert.ToDecimal(reader["SUBTOTAL"].ToString()),
                            });
                        }
                    }

                }
            }
            catch (Exception)
            {
                listaDetallesVentas = new List<DetalleVenta>();
            }

            return listaDetallesVentas;
        }
    }
}
