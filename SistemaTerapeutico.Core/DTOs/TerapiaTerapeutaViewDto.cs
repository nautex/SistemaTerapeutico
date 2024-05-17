using SistemaTerapeutico.Core.Entities;
using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaTerapeutaViewDto : BaseEntity2Ids
    {
        public int IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public int IdTipoCargo { get; set; }
        public string TipoCargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
