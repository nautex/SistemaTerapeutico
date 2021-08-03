using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? IdPaisOrigen { get; set; }
        public int IdTipoPersona { get; set; }
        public bool EsEmpresa { get; set; }
        public int? IdEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        //public DateTime? FechaModificacion { get; set; }
        //public string UsuarioModificacion { get; set; }
    }
}
