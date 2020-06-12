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
    }
}
