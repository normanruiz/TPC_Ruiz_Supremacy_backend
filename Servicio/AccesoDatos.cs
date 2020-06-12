using System;
using System.Data.SqlClient;

namespace Servicio
{
    public class AccesoDatos
    {
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }
        public SqlDataReader Lector { get; set; }
        string cadena = @"data source =.\SQLEXPRESS; initial catalog= Ruiz_Supremacy_backend_DB; integrated security=sspi";

        public AccesoDatos()
        {
            Conexion = new SqlConnection(cadena);
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void Conectar()
        {
            try
            {
                Conexion.Open();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void Desconectar()
        {
            try
            {
                Conexion.Close();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void EjecutarConsulta(string consulta)
        {
            try
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = consulta;
                Lector = Comando.ExecuteReader();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void EjecutarAccion(string consulta)
        {
            try
            {
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = consulta;
                Comando.ExecuteNonQuery();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public void AgregarParametro(string parametro, string valor)
        {
            try
            {
                Comando.Parameters.AddWithValue(parametro, valor);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }


        public void LimpiarParametro()
        {
            try
            {
                Comando.Parameters.Clear();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
