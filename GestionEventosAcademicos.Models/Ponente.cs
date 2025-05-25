using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosAcademicos.Models
{
    public class Ponente
    {
        public int Idponente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        // Navigation properties
        public List<Eventoponente> Eventoponentes { get; set; } = new List<Eventoponente>();
    }
}
