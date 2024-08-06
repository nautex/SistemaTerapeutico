using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class Area : BaseEntity
    {
        public Area()
        {
            AreaObjetivo = new List<AreaObjetivo>();
        }
        public int IdModelo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public List<AreaObjetivo> AreaObjetivo { get; set; }
    }
}
