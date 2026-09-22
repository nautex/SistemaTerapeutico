using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioDto : BaseEntityTwoIds
    {
        public int IdAreaObjetivoCriterio { get; set; }
        public int IdPuntuacionGrupo { get; set; }
    }
}
