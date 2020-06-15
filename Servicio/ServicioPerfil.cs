using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioPerfil
    {
        public List<Perfil> Listar()
        {
            List<Perfil> listadoPerfil;
            Perfil perfil;
            AccesoDatos conexion = null;
            try
            {
                listadoPerfil = new List<Perfil>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select p.Id, p.Tipo, p.Estado from perfiles as p");
                while (conexion.Lector.Read())
                {
                    perfil = new Perfil();
                    perfil.Id = (int)conexion.Lector["Id"];
                    perfil.Tipo = (string)conexion.Lector["Tipo"];
                    perfil.Estado = (bool)conexion.Lector["Estado"];

                    listadoPerfil.Add(perfil);
                }

                return listadoPerfil;
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

        public bool AgregarNuevo(Perfil perfil)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@Tipo", perfil.Tipo);
                conexion.AgregarParametro("@Estado", perfil.Estado.ToString());
                conexion.EjecutarAccion("insert into Perfiles values (@Tipo, @Estado)");
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

        public bool GuardarModificado(Perfil perfil)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();

                conexion.AgregarParametro("@Id", perfil.Id.ToString());
                conexion.AgregarParametro("@Tipo", perfil.Tipo);
                conexion.AgregarParametro("@Estado", perfil.Estado.ToString());

                conexion.EjecutarAccion("update perfiles set tipo=@Tipo, estado=@Estado where id=@Id");
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

                conexion.EjecutarAccion("delete from perfiles where Id=@Id");
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
