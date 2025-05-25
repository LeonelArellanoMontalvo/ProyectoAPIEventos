using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Asistencia
    {
        public int Idasistencia { get; set; }
        public int Idinscripcion { get; set; }
        public int Idactividad { get; set; }
        public bool Asistio { get; set; }

        // Navigation properties
        public Inscripcion? Inscripcion { get; set; }
        public Actividad? Actividad { get; set; }
    }
}
