using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Turno
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Especialidad Especialidad { get; set; }
        public Medico Medico { get; set; }
        public Horario Horario { get; set; }
        public Estado Estado { get; set; }
    }
}
