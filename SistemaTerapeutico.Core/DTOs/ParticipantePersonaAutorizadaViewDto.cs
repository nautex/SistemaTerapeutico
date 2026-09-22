using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipantePersonaAutorizadaViewDto : BaseEntityTwoIds
    {
        public int IdPersona { get; set; }
        public string Persona { get; set; }
    }
}
