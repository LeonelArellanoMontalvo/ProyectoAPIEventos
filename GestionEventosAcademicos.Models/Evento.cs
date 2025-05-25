using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Evento
    {
        public int Idevento { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int Costo { get; set; }

        // Navigation properties
        public List<Actividad> Actividades { get; set; } = new List<Actividad>();
        public List<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
        public List<Eventoponente> Eventoponentes { get; set; } = new List<Eventoponente>();
    }
}
