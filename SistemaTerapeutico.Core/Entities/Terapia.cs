using System;
using System.Collections.Generic;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Terapia : BaseEntity
    {
        public Terapia()
        {
            FechaInicio = DateTime.Now;
            TerapiaHorario = new List<TerapiaHorario>();
            TerapiaTerapeuta = new List<TerapiaTerapeuta>();
            TerapiaParticipante = new List<TerapiaParticipante>();
        }
        public int IdLocal { get; set; }
        public int IdTarifa { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdTipo { get; set; }
        public int IdModalidad { get; set; }
        public int SesionesMes { get; set; }
        public int MinutosSesion { get; set; }
        public int IdSalon { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public virtual List<TerapiaHorario> TerapiaHorario { get; set; }
        public virtual List<TerapiaTerapeuta> TerapiaTerapeuta { get; set; }
        public virtual List<TerapiaParticipante> TerapiaParticipante { get; set; }
    }
}
