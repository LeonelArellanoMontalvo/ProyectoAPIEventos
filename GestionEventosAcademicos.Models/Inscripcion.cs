using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Inscripcion
    {
        public int Idinscripcion { get; set; }
        public int Idevento { get; set; }
        public int Idparticipante { get; set; }
        public DateTime Fechainscripcion { get; set; }
        public string EstadoInscripcion { get; set; } = string.Empty;
        public DateTime? Fechapago { get; set; }
        public string Mediopago { get; set; } = string.Empty;
        public string EstadoPago { get; set; } = string.Empty;

        // Navigation properties
        public Evento? Evento { get; set; }
        public Participante? Participante { get; set; }
        public Certificado? Certificado { get; set; }
        public List<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
    }
}
