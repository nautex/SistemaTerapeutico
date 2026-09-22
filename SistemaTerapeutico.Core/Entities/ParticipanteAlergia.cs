using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class ParticipanteAlergia : BaseEntityTwoIds
    {
        public ParticipanteAlergia()
        {
            
        }
        public int? IdTipoAlergia { get; set; }
        public string Detalle { get; set; }
    }
}
