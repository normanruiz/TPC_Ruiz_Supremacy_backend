using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioPaciente
    {
        public List<Paciente> Listar()
        {
            List<Paciente> listadoPaciente;
            Paciente paciente;
            ServicioNota servicioNota; 
            AccesoDatos conexion = null;
            try
            {
                listadoPaciente = new List<Paciente>();
                servicioNota = new ServicioNota();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select p.Id, p.Nombre, p.Apellido, p.Sexo, p.FechaNacimiento, p.Estado from pacientes as p");
                while (conexion.Lector.Read())
                {
                    
                    paciente = new Paciente();
                    paciente.Id = (int)conexion.Lector["Id"];
                    paciente.Nombre = (string)conexion.Lector["Nombre"];
                    paciente.Apellido = (string)conexion.Lector["Apellido"];
                    paciente.Sexo = (string)conexion.Lector["Sexo"];
                    paciente.FechaNacimiento = (DateTime)conexion.Lector["FechaNacimiento"];

                    paciente.HistorialMedico = new List<Nota>();
                    paciente.HistorialMedico = servicioNota.Listar(paciente.Id);

                    paciente.Estado = (bool)conexion.Lector["Estado"];

                    listadoPaciente.Add(paciente);
                }

                return listadoPaciente;
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

        public bool AgregarNuevo(Paciente paciente)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@nombre", paciente.Nombre);
                conexion.AgregarParametro("@apellido", paciente.Apellido);
                conexion.AgregarParametro("@sexo", paciente.Sexo);
                conexion.AgregarParametro("@fechaNacimiento", paciente.FechaNacimiento.ToString("yyyy-MM-dd"));
                conexion.EjecutarAccion("insert into pacientes values ( @nombre, @apellido, @sexo, @fechaNacimiento, 1)");
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

        public bool GuardarModificado(Paciente paciente)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@id", paciente.Id.ToString());
                conexion.AgregarParametro("@nombre", paciente.Nombre);
                conexion.AgregarParametro("@apellido", paciente.Apellido);
                conexion.AgregarParametro("@sexo", paciente.Sexo);
                conexion.AgregarParametro("@fechaNacimiento", paciente.FechaNacimiento.ToString("yyyy-MM-dd"));
                conexion.AgregarParametro("@estado", paciente.Estado.ToString());
                conexion.EjecutarAccion("update pacientes set Nombre = @nombre, Apellido = @apellido, Sexo = @sexo, FechaNacimiento = @fechaNacimiento, Estado = @estado where Id = @id");
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

                conexion.EjecutarAccion("delete from pacientes where Id = @Id");
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
