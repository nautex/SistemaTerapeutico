using SistemaTerapeutico.Core.Entities;
using System;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaResumenView : Base
    {
        public string Nombres { get; set; }
        public string TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string TipoPersona { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
