using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string RazonSocial { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? IdPaisOrigen { get; set; }
        public int IdTipoPersona { get; set; }
        public bool EsEmpresa { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
