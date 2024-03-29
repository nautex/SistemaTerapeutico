﻿using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Sesion : BaseEntity
    {
        public Sesion()
        {
            Fecha = DateTime.Now;
            IdEstadoAsistencia = ETipoAsistenciaSesion.Normal;
            Observacion = "";
        }
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public int IdModalidad { get; set; }
        public int IdPuntuacionCriterio { get; set; }
        public int IdPuntuacionActividad { get; set; }
        public string Observacion { get; set; }

    }
}
