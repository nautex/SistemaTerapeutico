using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionTerapeutaViewDto : BaseEntity2Ids
    {
        public int IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public int IdTipoCargo { get; set; }
        public string TipoCargo { get; set; }
    }
}
