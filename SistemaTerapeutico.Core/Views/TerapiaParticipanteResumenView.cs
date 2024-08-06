using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class TerapiaParticipanteResumenView : Base
    {
        public TerapiaParticipanteResumenView()
        {
            EstadoCreacion = "P";
        }
        public int IdTerapia { get; set; }
        public int Numero { get; set; }
        public int IdTipoTerapia { get; set; }
        public string TipoTerapia { get; set; }
        public int? IdTipoTerapiaPadre { get; set; }
        public int IdParticipante { get; set; }
        public int IdPersona { get; set; }
        public string Participante { get; set; }
        public int? IdTerapeuta { get; set; }
        public string Terapeuta { get; set; }
        public int IdTarifa { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoCreacion { get; set; }
    }
}
