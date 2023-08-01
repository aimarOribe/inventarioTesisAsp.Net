using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CapaDatos
{
    public class cdCompra
    {
        public int ObtenerIdIncrementable()
        {
            int idIncrementable = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT COUNT(*) + 1 FROM COMPRA");
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

        public bool RegistrarCompra(Compra compra, DataTable dtDetalleCompra, out string mensaje)
        {
            bool Respuesta = false;
            mensaje = string.Empty;
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCOMPRA", conexion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO",compra.oUSUARIO.IDUSUARIO);
                    cmd.Parameters.AddWithValue("@IDPROVEEDOR",compra.oPROVEEDOR.IDPROVEEDOR);
                    cmd.Parameters.AddWithValue("@TIPODOCUMENTO",compra.TIPODOCUMENTO);
                    cmd.Parameters.AddWithValue("@NUMERODOCUMENTO",compra.NUMERODOCUMENTO);
                    cmd.Parameters.AddWithValue("@MONTOTOTAL",compra.MONTOTOTAL);
                    cmd.Parameters.AddWithValue("@DETALLECOMPRA",dtDetalleCompra);
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

        public Compra ObtenerCompra(string numeroDocumento)
        {
            Compra compra = new Compra();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT C.IDCOMPRA, U.NOMBRECOMPLETO, P.DOCUMENTO, P.RAZONSOCIAL, C.TIPODOCUMENTO, C.NUMERODOCUMENTO,");
                    query.AppendLine("C.MONTOTOTAL, CONVERT(CHAR(10), C.FECHAREGISTRO, 103) AS FECHAREGISTRO FROM COMPRA C");
                    query.AppendLine("INNER JOIN USUARIO U");
                    query.AppendLine("ON C.IDUSUARIO = U.IDUSUARIO");
                    query.AppendLine("INNER JOIN PROVEEDOR P");
                    query.AppendLine("ON C.IDPROVEEDOR = P.IDPROVEEDOR");
                    query.AppendLine("WHERE C.NUMERODOCUMENTO = @NUMERODOCUMENTO");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@NUMERODOCUMENTO", numeroDocumento);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            compra = new Compra 
                            {
                                IDCOMPRA = Convert.ToInt32(reader["IDCOMPRA"]),
                                oUSUARIO = new Usuario { NOMBRECOMPLETO = reader["NOMBRECOMPLETO"].ToString() },
                                oPROVEEDOR = new Proveedor { DOCUMENTO = reader["DOCUMENTO"].ToString(), RAZONSOCIAL = reader["RAZONSOCIAL"].ToString() },
                                TIPODOCUMENTO = reader["TIPODOCUMENTO"].ToString(),
                                NUMERODOCUMENTO = reader["NUMERODOCUMENTO"].ToString(),
                                MONTOTOTAL = Convert.ToDecimal(reader["MONTOTOTAL"]),
                                FECHAREGISTRO = reader["FECHAREGISTRO"].ToString()
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    compra = new Compra();
                }
            }
            return compra;
        }

        public List<DetalleCompra> ObtenerDetallesCompras(int idCompra)
        {
            List<DetalleCompra> listaDetallesCompras = new List<DetalleCompra>();
            Medida medida;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT P.NOMBRE, DC.PRECIOCOMPRA, DC.CANTIDAD, M.DESCRIPCION AS MEDIDA, DC.MONTOTOTAL FROM DETALLECOMPRA DC");
                    query.AppendLine("INNER JOIN PRODUCTO P");
                    query.AppendLine("ON DC.IDPRODUCTO = P.IDPRODUCTO");
                    query.AppendLine("INNER JOIN CATEGORIA C");
                    query.AppendLine("ON P.IDCATEGORIA = C.IDCATEGORIA");
                    query.AppendLine("INNER JOIN MEDIDA M");
                    query.AppendLine("ON C.IDMEDIDA = M.IDMEDIDA");
                    query.AppendLine("WHERE DC.IDCOMPRA = @IDCOMPRA");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IDCOMPRA", idCompra);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaDetallesCompras.Add(new DetalleCompra
                            {
                                oPRODUCTO = new Producto { NOMBRE = reader["NOMBRE"].ToString() , oCATEGORIA = new Categoria { oMEDIDA = new Medida { DESCRIPCION = reader["MEDIDA"].ToString() } } },
                                PRECIOCOMPRA = Convert.ToDecimal(reader["PRECIOCOMPRA"].ToString()),
                                CANTIDAD = Convert.ToInt32(reader["CANTIDAD"].ToString()), 
                                MONTOTOTAL = Convert.ToDecimal(reader["MONTOTOTAL"].ToString()),
                            });
                        }
                    }
                    
                }
            }
            catch (Exception)
            {
                listaDetallesCompras = new List<DetalleCompra>();
            }

            return listaDetallesCompras;
        }

    }
}
