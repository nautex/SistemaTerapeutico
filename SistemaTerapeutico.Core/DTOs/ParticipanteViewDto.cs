﻿using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteViewDto
    {
        public int IdParticipante { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdPadre { get; set; }
        public string Padre { get; set; }
        public int? IdMadre { get; set; }
        public string Madre { get; set; }
        public int? IdPersonaAutorizada { get; set; }
        public string PersonaAutorizada { get; set; }
        public string LugarCasoAccidente { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
