using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaDto : BaseEntity
    {
        public int IdLocal { get; set; }
        public int IdTarifa { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdTipo { get; set; }
        public int IdModalidad { get; set; }
        public int SesionesMes { get; set; }
        public int MinutosSesion { get; set; }
        public int IdSalon { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public virtual List<TerapiaHorarioViewDto> TerapiaHorario { get; set; }
        public virtual List<TerapiaTerapeuta> TerapiaTerapeuta { get; set; }
        public virtual List<TerapiaParticipante> TerapiaParticipante { get; set; }
    }
}
