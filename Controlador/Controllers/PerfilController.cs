using Modelo;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Controlador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PerfilController : ApiController
    {
        [HttpGet]
        public List<Perfil> Get()
        {
            ServicioPerfil servicioPerfil;

            try
            {
                servicioPerfil = new ServicioPerfil();
                return servicioPerfil.Listar();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPost]
        public bool Post([FromBody]Perfil perfil)
        {
            ServicioPerfil servicioPerfil;
            try
            {
                servicioPerfil = new ServicioPerfil();
                return servicioPerfil.AgregarNuevo(perfil);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpPut]
        public bool Put(int Id, [FromBody]Perfil perfil)
        {
            ServicioPerfil servicioPerfil;
            try
            {
                perfil.Id = Id;
                servicioPerfil = new ServicioPerfil();
                return servicioPerfil.GuardarModificado(perfil);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            ServicioPerfil servicioPerfil;
            try
            {
                servicioPerfil = new ServicioPerfil();
                return servicioPerfil.EliminarFisico(Id);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }
    }
}
