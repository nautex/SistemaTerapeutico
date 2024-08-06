using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AreaObjetivoCriterioDto : BaseEntity
    {
        public int IdAreaObjetivo { get; set; }
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
    }
}
