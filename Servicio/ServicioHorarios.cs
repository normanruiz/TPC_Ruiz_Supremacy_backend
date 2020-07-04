using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioHorarios
    {
        //public List<Horario> Listar()
        //{
        //    List<Horario> listadoHorarios;
        //    Horario horario;
        //    AccesoDatos conexion = null;
        //    try
        //    {
        //        listadoHorarios = new List<Horario>();
        //        conexion = new AccesoDatos();
        //        conexion.Conectar();
        //        conexion.EjecutarConsulta("");
        //        while (conexion.Lector.Read())
        //        {
        //            horario = new Horario();
        //            horario.Id = (int)conexion.Lector["Id"];
        //            horario.Inicio = (string)conexion.Lector["Nombre"];
        //            horario.Fin = (string)conexion.Lector["Apellido"];
        //            horario.Estado = (bool)conexion.Lector["Estado"];

        //            listadoHorarios.Add(horario);
        //        }

        //        return listadoHorarios;
        //    }
        //    catch (Exception excepcion)
        //    {
        //        throw excepcion;
        //    }
        //    finally
        //    {
        //        if (conexion != null)
        //        {
        //            conexion.Desconectar();
        //        }
        //    }

        //}

        public bool AgregarNuevo(Medico medico)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@nombre", medico.Nombre);
                conexion.AgregarParametro("@apellido", medico.Apellido);
                conexion.AgregarParametro("@correo", medico.Correo);
                conexion.AgregarParametro("@estado", medico.Estado.ToString());
                conexion.EjecutarAccion("insert into medicos values (@nombre, @apellido, @correo, @estado)");
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

        public bool GuardarModificado(Medico medico)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@id", medico.Id.ToString());
                conexion.AgregarParametro("@nombre", medico.Nombre);
                conexion.AgregarParametro("@apellido", medico.Apellido);
                conexion.AgregarParametro("@correo", medico.Correo);
                conexion.AgregarParametro("@estado", medico.Estado.ToString());
                conexion.EjecutarAccion("update medicos set Nombre = @nombre, Apellido = @apellido, Correo = @correo, Estado = @estado where Id = @id");
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

                conexion.EjecutarAccion("delete from medicos where Id = @Id");
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
