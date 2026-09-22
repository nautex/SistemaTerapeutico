using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AreaObjetivoViewDto : BaseEntity
    {
        public int IdModelo { get; set; }
        public string CodigoModelo { get; set; }
        public string Modelo { get; set; }
        public int? IdArea { get; set; }
        public string CodigoArea { get; set; }
        public int? OrdenArea { get; set; }
        public string Area { get; set; }
        public int? IdDestreza { get; set; }
        public string CodigoDestreza { get; set; }
        public string Destreza { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        public string Pregunta { get; set; }
        public string Ejemplo { get; set; }
    }
}
