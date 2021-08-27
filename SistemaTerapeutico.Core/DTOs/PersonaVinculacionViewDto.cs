using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaVinculacionViewDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int IdPersonaVinculo { get; set; }
        public int IdTipoVinculo { get; set; }
        public string PersonaVinculo { get; set; }
    }
}
