using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanAreaViewDto : BaseEntity2Ids
    {
        public int IdTerapia { get; set; }
        public int IdArea { get; set; }
        public string CodigoArea { get; set; }
        public int OrdenArea { get; set; }
        public string Area { get; set; }
        public int IdModelo { get; set; }
        public string CodigoModelo { get; set; }
        public string Modelo { get; set; }
        public int Orden { get; set; }
    }
}
