﻿using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanViewDto : BaseEntity
    {
        public int IdTerapia { get; set; }
        public int IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public int IdParticipante { get; set; }
        public string Participante { get; set; }
        public int IdPeriodo { get; set; }
        public string CodigoPeriodo { get; set; }
        public DateTime FechaInicioPeriodo { get; set; }
        public DateTime FechaFinPeriodo { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdEstadoVigencia { get; set; }
        public string EstadoVigencia { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
