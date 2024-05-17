using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaDocumentoView : BaseEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
