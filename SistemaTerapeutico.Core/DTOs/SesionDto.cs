using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionDto : BaseEntity
    {
        public int IdTerapiaPeriodo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public int IdModalidad { get; set; }
        public int IdPuntuacionCriterio { get; set; }
        public int IdPuntuacionActividad { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public virtual List<SesionTerapeutaViewDto> SesionTerapeuta { get; set; }
    }
}
