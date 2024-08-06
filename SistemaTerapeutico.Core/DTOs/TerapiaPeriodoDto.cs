using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPeriodoDto : BaseEntity
    {
        public int IdTerapia { get; set; }
        public int Numero { get; set; }
        public int IdPeriodo { get; set; }
        public int IdEstado { get; set; }
    }
}
