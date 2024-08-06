using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaResumenViewDto : Base
    {
        public int IdTerapia { get; set; }
        public int? Numero { get; set; }
        public int IdLocal { get; set; }
        public string Local { get; set; }
        public string CodigoServicio { get; set; }
        public string CodigoTarifa { get; set; }
        public int? IdParticipante { get; set; }
        public string Participante { get; set; }
        public int? IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public string Horario { get; set; }
        public string Salon { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
