using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class DestrezaDto : BaseEntity
    {
        public DestrezaDto() { }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? EdadMesesInicio { get; set; }
        public int? EdadMesesFin { get; set; }
        public string Descripcion { get; set; }
    }
}
