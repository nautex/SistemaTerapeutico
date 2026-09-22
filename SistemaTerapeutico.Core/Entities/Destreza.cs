using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Entities
{
    public class Destreza : BaseEntity
    {
        public Destreza()
        {
            
        }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? EdadMesesInicio { get; set; }
        public int? EdadMesesFin { get; set; }
        public string Descripcion { get; set; }
    }
}
