using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionViewDto : BaseEntity
    {
        public int IdTerapiaPeriodo { get; set; }
        public int IdTerapia { get; set; }
        public string CodigoPeriodo { get; set; }
        public string Participante { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public string EstadoAsistencia { get; set; }
        public int IdModalidad { get; set; }
        public string Modalidad { get; set; }
        public int IdPuntuacionCriterio { get; set; }
        public string PuntuacionCriterio { get; set; }
        public int IdPuntuacionActividad { get; set; }
        public string PuntuacionActividad { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public virtual List<SesionTerapeutaViewDto> SesionTerapeuta { get; set; }
        public virtual List<SesionCriterioViewDto> SesionCriterio { get; set; }
    }
}
