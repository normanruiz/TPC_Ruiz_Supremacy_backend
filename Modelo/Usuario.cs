using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public Perfil Perfil { get; set; }
        public string Usr { get; set; }
        public string Pwd { get; set; }
        public bool Estado { get; set; }
    }
}
