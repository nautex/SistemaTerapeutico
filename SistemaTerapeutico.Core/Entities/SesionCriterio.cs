namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterio : BaseEntityTwoIds
    {
        public SesionCriterio()
        {

        }
        public int IdAreaObjetivoCriterio { get; set; }
        public int IdPuntuacionGrupo { get; set; }
    }
}
