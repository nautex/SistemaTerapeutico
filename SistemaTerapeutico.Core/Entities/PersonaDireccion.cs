namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDireccion : BaseEntity
    {
        public int Numero { get; set; }
        public int? IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public int? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNavigation { get; set; }
    }
}
