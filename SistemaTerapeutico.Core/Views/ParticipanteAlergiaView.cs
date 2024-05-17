using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class ParticipanteAlergiaView : BaseEntity2Ids
    {
        public int IdTipoAlergia { get; set; }
        public string TipoAlergia { get; set; }
        public string Detalle { get; set; }
    }
}
