using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Nota> HistorialMedico { get; set; }
        public bool Estado { get; set; }
    }
}
