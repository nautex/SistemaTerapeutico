using System;

namespace SistemaTerapeutico.Core.Entities
{
    public class Participante : BaseEntity
    {
        public Participante()
        {

        }
        public int IdTerapeuta { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string LugarCasoAccidente { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }

    }
}
