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
            AccesoDatos conexion = null;
            try
            {
                listadoPaciente = new List<Paciente>();
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
    }
}
