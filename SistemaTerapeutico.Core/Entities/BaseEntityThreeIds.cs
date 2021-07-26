namespace SistemaTerapeutico.Core.Entities
{
    public class BaseEntityThreeIds : BaseEntityTwoIds
    {
        public BaseEntityThreeIds(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdThree { get; set; }
    }
}
