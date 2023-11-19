using System.Data.SqlClient;
using System;

public class Conexion
{
    private string BD;
    private string Servidor;
    private string Usuario;
    private string Clave;
    private bool Seguridad;
    private static Conexion Cnx = null;
    private SqlConnection connection;

    private Conexion()
    {
        this.BD = "Tienda";
        this.Servidor = "LDB-Nitro5\\MSSQLSERVER02";
        this.Usuario = "";
        this.Clave = "";
        this.Seguridad = true;
    }

    public SqlConnection ConexionBD()
    {
        if (connection == null)
        {
            connection = new SqlConnection();

            try
            {
                connection.ConnectionString = $"Server = {this.Servidor}, Database = {this.BD}";
                if (this.Seguridad)
                {
                    connection.ConnectionString = connection.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    connection.ConnectionString = connection.ConnectionString + $"User Id={this.Usuario};Password={this.Clave}";
                }

                connection.Open();
            }
            catch (Exception ex)
            {
                connection = null;
                throw ex;
            }
        }

        return connection;
    }

    public static Conexion obtenerCNX()
    {
        if (Cnx == null)
        {
            Cnx = new Conexion();
        }
        return Cnx;
    }

    public static void CerrarConexion()
    {
        if (Cnx != null && Cnx.connection != null)
        {
            Cnx.connection.Close();
            Cnx.connection = null;
        }
    }
}
