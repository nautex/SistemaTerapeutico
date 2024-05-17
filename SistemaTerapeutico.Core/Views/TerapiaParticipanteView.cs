using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class TerapiaParticipanteView : BaseEntity2Ids
    {
        public int IdParticipante { get; set; }
        public int? IdPersona { get; set; }
        public string Participante { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
