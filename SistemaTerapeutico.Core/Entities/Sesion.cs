using System;
using System.Collections.Generic;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Sesion : BaseEntity
    {
        public Sesion()
        {
            Fecha = DateTime.Now;
            IdEstadoAsistencia = ETipoAsistenciaSesion.Normal;
            IdEstado = EEstadoBasico.Activo;
            Observaciones = "";
            SesionTerapeuta = new List<SesionTerapeuta>();
        }
        public int IdTerapiaPeriodo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public int IdModalidad { get; set; }
        public int IdPuntuacionCriterio { get; set; }
        public int IdPuntuacionActividad { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public virtual List<SesionTerapeuta> SesionTerapeuta { get; set; }
        public virtual List<SesionCriterio> SesionCriterio { get; set; }
    }
}
