using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteAlergiaViewDto : BaseEntity2Ids
    {
        public int IdTipoAlergia { get; set; }
        public string TipoAlergia { get; set; }
        public string Detalle { get; set; }
    }
}
