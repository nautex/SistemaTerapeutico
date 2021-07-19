using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaTerapeuta : BaseEntityTwoIds
    {
        public TerapiaTerapeuta(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdTipoCargo = ETipoCargoTerapeuta.Titular;
            FechaInicio = DateTime.Now;
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdTipoCargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }
    }
}
