using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDireccion : BaseEntity
    {
        public int Numero { get; set; }
        public int? IdDireccion { get; set; }
        public eTipoDireccion? IdTipoDireccion { get; set; }
        public eEstadoBasico? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNavigation { get; set; }
    }
}
