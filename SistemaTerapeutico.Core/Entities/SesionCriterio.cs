namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterio : BaseEntity
    {
        public SesionCriterio(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdSesion { get; set; }
        public int IdObjetivoCriterio { get; set; }
    }
}
