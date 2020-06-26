using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioMedico
    {
        public List<Medico> Listar()
        {
            List<Medico> listadoMedicos;
            Medico medico;
            AccesoDatos conexion = null;
            try
            {
                listadoMedicos = new List<Medico>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select m.Id, m.Nombre, m.Apellido, m.Correo, m.Estado from medicos as m;");
                while (conexion.Lector.Read())
                {
                    medico = new Medico();
                    medico.Id = (int)conexion.Lector["Id"];
                    medico.Nombre = (string)conexion.Lector["Nombre"];
                    medico.Apellido = (string)conexion.Lector["Apellido"];
                    medico.Correo = (string)conexion.Lector["Correo"];
                    medico.Estado = (bool)conexion.Lector["Estado"];

                    listadoMedicos.Add(medico);
                }

                return listadoMedicos;
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
