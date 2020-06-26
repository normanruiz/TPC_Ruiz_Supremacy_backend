using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class ServicioUsuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> listadoUsuarios;
            Usuario usuario;
            AccesoDatos conexion = null;
            try
            {
                listadoUsuarios = new List<Usuario>();
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.EjecutarConsulta("select u.Id, u.Nombre, u.Apellido, u.Correo, u.IdPerfil, p.Tipo, u.Usr, u.Pwd, u.Estado from usuarios as u inner join perfiles as p on u.IdPerfil = p.Id");
                while (conexion.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = (int)conexion.Lector["Id"];
                    usuario.Nombre = (string)conexion.Lector["Nombre"];
                    usuario.Apellido = (string)conexion.Lector["Apellido"];
                    usuario.Correo = (string)conexion.Lector["Correo"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.Id = (int)conexion.Lector["IdPerfil"];
                    usuario.Perfil.Tipo = (string)conexion.Lector["Tipo"];
                    usuario.Usr = (string)conexion.Lector["Usr"];
                    usuario.Pwd = (string)conexion.Lector["Pwd"];
                    usuario.Estado = (bool)conexion.Lector["Estado"];

                    listadoUsuarios.Add(usuario);
                }

                return listadoUsuarios;
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

        public bool AgregarNuevo(Usuario usuario)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@nombre", usuario.Nombre);
                conexion.AgregarParametro("@apellido", usuario.Apellido);
                conexion.AgregarParametro("@correo", usuario.Correo);
                conexion.AgregarParametro("@idPerfil", usuario.Perfil.Id.ToString());
                conexion.AgregarParametro("@usr", usuario.Usr);
                conexion.AgregarParametro("@pwd", usuario.Pwd);
                conexion.EjecutarAccion("insert into usuarios values(@nombre, @apellido, @correo, @idPerfil, @usr, @pwd, 1)");
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

        public bool GuardarModificado(Usuario usuario)
        {
            AccesoDatos conexion = null;
            bool progreso = false;
            try
            {
                conexion = new AccesoDatos();
                conexion.Conectar();
                conexion.LimpiarParametro();
                conexion.AgregarParametro("@id", usuario.Id.ToString());
                conexion.AgregarParametro("@nombre", usuario.Nombre);
                conexion.AgregarParametro("@apellido", usuario.Apellido);
                conexion.AgregarParametro("@correo", usuario.Correo);
                conexion.AgregarParametro("@idPerfil", usuario.Perfil.Id.ToString());
                conexion.AgregarParametro("@usr", usuario.Usr);
                conexion.AgregarParametro("@pwd", usuario.Pwd);
                conexion.AgregarParametro("@estado", usuario.Estado.ToString());
                conexion.EjecutarAccion("update usuarios set Nombre = @nombre, Apellido = @apellido, Correo = @correo, IdPerfil = @idPerfil, Usr = @usr, Pwd = @pwd, Estado = @estado where Id = @id");
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

                conexion.EjecutarAccion("delete from usuarios where Id=@Id");
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
