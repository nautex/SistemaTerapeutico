using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class Modelo : BaseEntity
    {
        public Modelo()
        {
            Area = new List<Area>();
        }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Area> Area { get; set; }
    }
}
