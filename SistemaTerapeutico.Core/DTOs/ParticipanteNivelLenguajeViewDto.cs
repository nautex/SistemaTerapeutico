using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteNivelLenguajeViewDto : BaseEntityTwoIds
    {
        public int IdNivelLenguaje { get; set; }
        public string NivelLenguaje { get; set; }
    }
}
