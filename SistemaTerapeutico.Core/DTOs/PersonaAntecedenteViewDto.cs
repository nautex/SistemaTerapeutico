using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaAntecedenteViewDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoAntecedente { get; set; }
        public string TipoAntecedente { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
