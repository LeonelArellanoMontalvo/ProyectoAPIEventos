using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Certificado
    {
        public int Idcertificado { get; set; }
        public int Idinscripcion { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool EstadoCertificado { get; set; }

        // Navigation properties
        public Inscripcion? Inscripcion { get; set; }
    }
}
