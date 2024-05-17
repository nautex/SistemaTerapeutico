using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class Local : BaseEntity
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdDireccion { get; set; }
        public int IdTipo { get; set; }
        public int IdEstado { get; set; }
    }
}
