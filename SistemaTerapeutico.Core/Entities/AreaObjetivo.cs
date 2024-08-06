using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class AreaObjetivo : BaseEntity
    {
        public AreaObjetivo()
        {
            AreaObjetivoCriterio = new List<AreaObjetivoCriterio>();
        }
        public int IdArea { get; set; }
        public int IdDestreza { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public string Pregunta { get; set; }
        public string Ejemplo { get; set; }
        public List<AreaObjetivoCriterio> AreaObjetivoCriterio { get; set; }
    }
}
