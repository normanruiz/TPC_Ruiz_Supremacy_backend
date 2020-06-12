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
    }
}
