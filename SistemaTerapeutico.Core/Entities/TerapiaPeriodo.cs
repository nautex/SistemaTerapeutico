namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPeriodo : BaseEntity
    {
        public TerapiaPeriodo()
        {

        }
        public int IdTerapia { get; set; }
        public int Numero { get; set; }
        public int IdPeriodo { get; set; }
        public int IdTarifa { get; set; }
        public int IdEstado { get; set; }
    }
}
