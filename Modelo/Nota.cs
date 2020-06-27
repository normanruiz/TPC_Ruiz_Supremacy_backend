using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Nota
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public bool Estado { get; set; }
    }
}
