using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionResumenViewDto : Base
    {
        public int IdTerapiaPeriodo { get; set; }
        public int IdTerapia { get; set; }
        public int Numero { get; set; }
        public int IdPeriodo { get; set; }
        public string CodigoPeriodo { get; set; }
        public string EstadoApertura { get; set; }
        public string Participante { get; set; }
        public int IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string EstadoAsistencia { get; set; }
        public string Modalidad { get; set; }
        public string PuntuacionCriterio { get; set; }
        public string PuntuacionActividad { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
