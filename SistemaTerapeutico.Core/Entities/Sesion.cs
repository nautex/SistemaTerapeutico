using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Sesion : BaseEntity
    {
        public Sesion(string usuarioRegistro) : base(usuarioRegistro)
        {
            Fecha = DateTime.Now;
            IdEstadoAsistencia = ETipoAsistenciaSesion.Normal;
            Observacion = "";
        }
        public int IdTerapia { get; set; }
        public int IdPeriodoTerapia { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public string Observacion { get; set; }

    }
}
