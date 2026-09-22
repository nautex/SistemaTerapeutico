using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AreaObjetivoCriterioResumenViewDto : Base
    {
        public int IdModelo { get; set; }
        public string CodigoModelo { get; set; }
        public string Modelo { get; set; }
        public int? IdArea { get; set; }
        public string CodigoArea { get; set; }
        public int? OrdenArea { get; set; }
        public string Area { get; set; }
        public int? IdAreaObjetivo { get; set; }
        public int? IdDestreza { get; set; }
        public string CodigoDestreza { get; set; }
        public string Destreza { get; set; }
        public string CodigoObjetivo { get; set; }
        public int? OrdenObjetivo { get; set; }
        public string Objetivo { get; set; }
        public int? Valor { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
    }
}
