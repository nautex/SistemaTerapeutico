using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaVinculacionView : BaseEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdPersonaVinculo { get; set; }
        public int IdTipoVinculo { get; set; }
        public string PersonaVinculo { get; set; }
    }
}
