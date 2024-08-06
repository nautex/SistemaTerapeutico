using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPeriodoResumenViewDto : Base
    {
        public int IdTerapia { get; set; }
        public int Numero { get; set; }
        public int IdPeriodo { get; set; }
        public int IdTipoTerapia { get; set; }
        public string TipoTerapia { get; set; }
        public DateTime FechaInicio { get; set; }
        public string CodigoPeriodo { get; set; }
        public int IdEstadoApertura { get; set; }
        public string EstadoApertura { get; set; }
        public string Participante { get; set; }
        public int? IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public int IdTarifa { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoCreacion { get; set; }
    }
}
