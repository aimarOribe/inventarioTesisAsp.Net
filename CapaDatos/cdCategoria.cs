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
    public class cdCategoria
    {
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT C.IDCATEGORIA,C.DESCRIPCION,C.ESTADO,M.IDMEDIDA,M.DESCRIPCION AS MEDIDA FROM CATEGORIA C");
                    query.AppendLine("INNER JOIN MEDIDA M");
                    query.AppendLine("ON C.IDMEDIDA = M.IDMEDIDA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Categoria
                            {
                                IDCATEGORIA = Convert.ToInt32(reader["IDCATEGORIA"]),
                                DESCRIPCION = reader["DESCRIPCION"].ToString(),
                                ESTADO = Convert.ToBoolean(reader["ESTADO"]),
                                oMEDIDA = new Medida { IDMEDIDA = Convert.ToInt32(reader["IDMEDIDA"]), DESCRIPCION = reader["MEDIDA"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<Categoria>();
                }
            }
            return lista;
        }

        public int RegistrarCategoria(Categoria Categoria, out string Mensaje)
        {
            int idCategoriaGenerada = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_REGISTRARCATEGORIA", conexion);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@IDMEDIDA", Categoria.oMEDIDA.IDMEDIDA);
                    cmd.Parameters.AddWithValue("@ESTADO", Categoria.ESTADO);
                    cmd.Parameters.Add("@RESULTADO", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@MENSAJE", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idCategoriaGenerada = Convert.ToInt32(cmd.Parameters["@RESULTADO"].Value);
                    Mensaje = cmd.Parameters["@MENSAJE"].Value.ToString();
                }
            }
            catch (Exception e)
            {
                idCategoriaGenerada = 0;
                Mensaje = e.Message;
            }

            return idCategoriaGenerada;
        }

        public bool EditarCategoria(Categoria Categoria, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_EDITARCATEGORIA", conexion);
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IDCATEGORIA);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@IDMEDIDA", Categoria.oMEDIDA.IDMEDIDA);
                    cmd.Parameters.AddWithValue("@ESTADO", Categoria.ESTADO);
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

        public bool EliminarCategoria(Categoria Categoria, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SR_ELIMINARCATEGORIA", conexion);
                    cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IDCATEGORIA);
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
