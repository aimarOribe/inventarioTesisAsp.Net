using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class cdReporte
    {
        public List<ReporteCompra> ObtenerReporteCompra(string fechaInicio, string fechaFin, int idProveedor)
        {
            List<ReporteCompra> listaReporteCompra = new List<ReporteCompra>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTECOMPRA", conexion);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin);
                    cmd.Parameters.AddWithValue("@IDPROVEEDOR", idProveedor);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaReporteCompra.Add(new ReporteCompra
                            {
                                FECHAREGISTRO = dr["FECHAREGISTRO"].ToString(),
                                TIPODOCUMENTO = dr["TIPODOCUMENTO"].ToString(),
                                NUMERODOCUMENTO = dr["NUMERODOCUMENTO"].ToString(),
                                MONTOTOTAL = dr["MONTOTOTAL"].ToString(),
                                USUARIOREGISTRO = dr["USUARIOREGISTRO"].ToString(),
                                DOCUMENTOPROVEEDOR = dr["DOCUMENTOPROVEEDOR"].ToString(),
                                RAZONSOCIAL = dr["RAZONSOCIAL"].ToString(),
                                CODIGOPRODUCTO = dr["CODIGOPRODUCTO"].ToString(),
                                NOMBREPRODUCTO = dr["NOMBREPRODUCTO"].ToString(),
                                CATEGORIA = dr["CATEGORIA"].ToString(),
                                PRECIOCOMPRA = dr["PRECIOCOMPRA"].ToString(),
                                PRECIOVENTA = dr["PRECIOVENTA"].ToString(),
                                CANTIDAD = dr["CANTIDAD"].ToString(),
                                MEDIDA = dr["MEDIDA"].ToString(),
                                SUBTOTAL = dr["SUBTOTAL"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaReporteCompra = new List<ReporteCompra>();
                }
            }
            return listaReporteCompra;
        }

        public List<ReporteVenta> ObtenerReporteVenta(string fechaInicio, string fechaFin)
        {
            List<ReporteVenta> listaReporteVenta = new List<ReporteVenta>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTEVENTA", conexion);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaReporteVenta.Add(new ReporteVenta
                            {
                                FECHAREGISTRO = dr["FECHAREGISTRO"].ToString(),
                                TIPODOCUMENTO = dr["TIPODOCUMENTO"].ToString(),
                                NUMERODOCUMENTO = dr["NUMERODOCUMENTO"].ToString(),
                                MONTOTOTAL = dr["MONTOTOTAL"].ToString(),
                                USUARIOREGISTRO = dr["USUARIOREGISTRO"].ToString(),
                                DOCUMENTOCLIENTE = dr["DOCUMENTOCLIENTE"].ToString(),
                                NOMBRECLIENTE = dr["NOMBRECLIENTE"].ToString(),
                                CODIGOPRODUCTO = dr["CODIGOPRODUCTO"].ToString(),
                                NOMBREPRODUCTO = dr["NOMBREPRODUCTO"].ToString(),
                                CATEGORIA = dr["CATEGORIA"].ToString(),
                                PRECIOVENTA = dr["PRECIOVENTA"].ToString(),
                                CANTIDAD = dr["CANTIDAD"].ToString(),
                                MEDIDA = dr["MEDIDA"].ToString(),
                                SUBTOTAL = dr["SUBTOTAL"].ToString(),
                            });
                        }
                    }

                }
                catch (Exception)
                {
                    listaReporteVenta = new List<ReporteVenta>();
                }
            }
            return listaReporteVenta;
        }
    }
}
