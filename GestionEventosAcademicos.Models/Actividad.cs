using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Actividad
    {
        public int Idactividad { get; set; }
        public int Idevento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public string Sala { get; set; } = string.Empty;

        // Navigation properties
        public Evento? Evento { get; set; }
        public List<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
