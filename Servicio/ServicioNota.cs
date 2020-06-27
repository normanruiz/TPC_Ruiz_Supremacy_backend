using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioNota
    {
        public List<Nota> Listar()
        {
            List<Nota> listadoNotas;
            Nota nota;
            AccesoDatos conexion = null;
            try
            {
                listadoNotas = new List<Nota>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select n.Id, n.IdPaciente, n.Fecha, n.Detalle, n.Estado from notas as n");
                while (conexion.Lector.Read())
                {
                    nota = new Nota();
                    nota.Id = (int)conexion.Lector["Id"];
                    nota.IdPaciente = (int)conexion.Lector["IdPaciente"];
                    nota.Fecha = (DateTime)conexion.Lector["Fecha"];
                    nota.Detalle = (string)conexion.Lector["Detalle"];
                    nota.Estado = (bool)conexion.Lector["Estado"];

                    listadoNotas.Add(nota);
                }

                return listadoNotas;
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

        public bool AgregarNuevo(Nota nota)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@idPaciente", nota.IdPaciente.ToString());
                conexion.AgregarParametro("@fecha", nota.Fecha.ToString("yyyy-MM-dd"));
                conexion.AgregarParametro("@detalle", nota.Detalle);
                conexion.EjecutarAccion("insert into notas values (@idPaciente, @fecha, @detalle, 1)");
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

        public bool GuardarModificado(Nota nota)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@id", nota.Id.ToString());
                conexion.AgregarParametro("@idPaciente", nota.IdPaciente.ToString());
                conexion.AgregarParametro("@fecha", nota.Fecha.ToString("yyyy-MM-dd"));
                conexion.AgregarParametro("@detalle", nota.Detalle);
                conexion.AgregarParametro("@estado", nota.Estado.ToString());
                conexion.EjecutarAccion("update notas set IdPaciente = @idPaciente, Fecha = @fecha, detalle = @detalle, Estado = @estado where Id = @id");
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

                conexion.EjecutarAccion("delete from notas where Id = @Id");
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
