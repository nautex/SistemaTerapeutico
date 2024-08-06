using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioDto : BaseEntity2Ids
    {
        public int IdAreaObjetivoCriterio { get; set; }
        public int IdPuntuacionGrupo { get; set; }
    }
}
