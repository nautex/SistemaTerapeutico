using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaParticipante : BaseEntityTwoIds
    {
        public int IdParticipante { get; set; }
        public int IdEstado { get; set; }
    }
}
