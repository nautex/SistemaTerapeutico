namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterio : BaseEntity2Ids
    {
        public SesionCriterio()
        {

        }
        public int IdAreaObjetivoCriterio { get; set; }
        public int IdPuntuacionGrupo { get; set; }
    }
}
