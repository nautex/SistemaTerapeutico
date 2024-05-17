using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaTerapeuta : BaseEntity2Ids
    {
        public TerapiaTerapeuta()
        {
            IdTipoCargo = ETipoCargoTerapeuta.Titular;
            FechaInicio = DateTime.Now;
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdTerapeuta { get; set; }
        public int IdTipoCargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdEstado { get; set; }
    }
}
