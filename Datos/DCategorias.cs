using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class DCategorias
    {
        public DataTable Listar () 
        {
            SqlDataReader resultado;
            DataTable Tabla1 = new DataTable ();
            SqlConnection conSql = new SqlConnection();

            try 
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand comando1 = new SqlCommand("categoria_listar",conSql);
                comando1.CommandType = CommandType.StoredProcedure;
                conSql.Open ();
                resultado = comando1.ExecuteReader ();
                Tabla1.Load (resultado);
                return Tabla1;
            }

            catch (Exception ex) 
            {
                throw ex;
            }
            finally 
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
                
            }
        }

        public DataTable Buscar (String Valor) 
        {
            SqlDataReader resultado;
            DataTable Tabla1 = new DataTable();
            SqlConnection conSql = new SqlConnection();

            try
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand comando2 = new SqlCommand("categoria_buscar", conSql);
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Valor;
                conSql.Open();
                resultado = comando2.ExecuteReader();
                Tabla1.Load(resultado);
                return Tabla1;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();

            }
        }

        public string Insertar (Categoria Obj) 
        {
            string respuesta = "";
            SqlConnection conSql = new SqlConnection();

            try 
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand comando3 = new SqlCommand("categoria_insertar",conSql);
                comando3.CommandType = CommandType.StoredProcedure;
                comando3.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                comando3.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                conSql.Open();
                respuesta = comando3.ExecuteNonQuery() == 1 ? "OK" : "No se puede ingresar el registro";
            }

            catch (Exception ex)
            {
                respuesta = ex.Message;
            }

            finally 
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
            }
            return respuesta;
        }

        public string Actualizar (Categoria Obj) 
        {
            string Respuesta2 = "";
            SqlConnection conSql = new SqlConnection();
            try
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand Comando4 = new SqlCommand("categoria_actualizar", conSql);
                Comando4.CommandType = CommandType.StoredProcedure;
                Comando4.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria;
                Comando4.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando4.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                conSql.Open();
                Respuesta2 = Comando4.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                Respuesta2 = ex.Message;
            }
            finally
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
            }
            return Respuesta2;
        }

        public string Eliminar(int Id)
        {
            string Respuesta3 = "";
            SqlConnection conSql = new SqlConnection();
            try
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand Comando5 = new SqlCommand("categoria_eliminar", conSql);
                Comando5.CommandType = CommandType.StoredProcedure;
                Comando5.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
                conSql.Open();
                Respuesta3 = Comando5.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Respuesta3 = ex.Message;
            }
            finally
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
            }
            return Respuesta3;
        }


        public string Activar(int Id)
        {
            string Respuesta4 = "";
            SqlConnection conSql = new SqlConnection();
            try
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand Comando6 = new SqlCommand("categoria_activar", conSql);
                Comando6.CommandType = CommandType.StoredProcedure;
                Comando6.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
                conSql.Open();
                Respuesta4 = Comando6.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Respuesta4 = ex.Message;
            }
            finally
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
            }
            return Respuesta4;
        }

        public string Desactivar(int Id)
        {
            string Respuesta5 = "";
            SqlConnection conSql = new SqlConnection();
            try
            {
                conSql = Conexion.obtenerCNX().ConexionBD();
                SqlCommand Comando6 = new SqlCommand("categoria_eliminar", conSql);
                Comando6.CommandType = CommandType.StoredProcedure;
                Comando6.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
                conSql.Open();
                Respuesta5 = Comando6.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Respuesta5 = ex.Message;
            }
            finally
            {
                if (conSql.State == ConnectionState.Open) conSql.Close();
            }
            return Respuesta5;
        }
    }

}
