using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanDto : BaseEntity
    {
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdEstado { get; set; }
        public int IdEstadoVigencia { get; set; }
        public virtual List<TerapiaPlanArea> TerapiaPlanArea { get; set; }
    }
}
