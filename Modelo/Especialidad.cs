using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Medico> ListaMedicos { get; set; }
        public List<Horario> ListaHorarios { get; set; }
        public bool Estado { get; set; }
    }
}
