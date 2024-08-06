using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AreaObjetivoDto : BaseEntity
    {
        public int IdArea { get; set; }
        public int IdDestreza { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public string Pregunta { get; set; }
        public string Ejemplo { get; set; }
    }
}
