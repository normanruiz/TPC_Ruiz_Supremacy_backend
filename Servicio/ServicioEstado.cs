using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioEstado
    {
        public List<Estado> Listar()
        {
            List<Estado> listadoEstado;
            Estado estado;
            AccesoDatos conexion = null;
            try
            {
                listadoEstado = new List<Estado>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select e.Id, e.Tipo, e.Estado from estados as e");
                while (conexion.Lector.Read())
                {
                    estado = new Estado();
                    estado.Id = (int)conexion.Lector["Id"];
                    estado.Tipo = (string)conexion.Lector["Tipo"];
                    estado.estado = (bool)conexion.Lector["Estado"];

                    listadoEstado.Add(estado);
                }

                return listadoEstado;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }

        }

        public bool AgregarNuevo(Estado estado)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@tipo", estado.Tipo);
                conexion.EjecutarAccion("insert into estados values (@Tipo, 1)");
                progreso = true;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }
            return progreso;
        }

        public bool GuardarModificado(Estado estado)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@id", estado.Id.ToString());
                conexion.AgregarParametro("@tipo", estado.Tipo);
                conexion.AgregarParametro("@estado", estado.estado.ToString());
                conexion.EjecutarAccion("update estados set Tipo = @tipo, Estado = @estado where Id = @id");
                progreso = true;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }
            return progreso;
        }

        public bool EliminarFisico(int Id)
        {
            bool progreso = false;
            AccesoDatos conexion = null;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@Id", Id.ToString());

                conexion.EjecutarAccion("delete from estados where Id = @Id");
                progreso = true;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Desconectar();
                }
            }
            return progreso;
        }

    }
}
