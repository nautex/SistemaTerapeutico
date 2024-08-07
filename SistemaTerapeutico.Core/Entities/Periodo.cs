﻿using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Periodo : BaseEntity
    {
        public Periodo()
        {
            IdEstado = EEstadoBasico.Activo;
            Observaciones = "";
        }
        public int IdTipoTerapia { get; set; }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public int? IdEstadoApertura { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
    }
}
