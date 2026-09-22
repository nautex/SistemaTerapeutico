using SistemaTerapeutico.Core.Entities;
using System;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaResumenBasicoView : Base
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public bool EsEmpresa { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
