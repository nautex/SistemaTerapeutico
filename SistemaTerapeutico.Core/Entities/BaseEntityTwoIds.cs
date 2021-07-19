namespace SistemaTerapeutico.Core.Entities
{
    public class BaseEntityTwoIds : BaseEntity
    {
        public BaseEntityTwoIds(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdTwo { get; set; }
    }
}
