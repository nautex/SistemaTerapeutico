namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaContacto : BaseEntity
    {
        public int Numero { get; set; }
        public int? IdTipoContacto { get; set; }
        public string Valor { get; set; }
        public int? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
