using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public bool Estado { get; set; }
    }
}
