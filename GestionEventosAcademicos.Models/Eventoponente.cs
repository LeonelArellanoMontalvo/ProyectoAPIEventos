using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Eventoponente
    {
        public int Idevento { get; set; }
        public int Idponente { get; set; }

        // Navigation properties
        public Evento? Evento { get; set; }
        public Ponente? Ponente { get; set; }
    }
}
