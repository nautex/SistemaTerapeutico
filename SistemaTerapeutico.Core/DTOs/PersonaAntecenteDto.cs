using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaAntecenteDto : BaseEntityTwoIds
    {
        public int? IdAntecedente { get; set; }
    }
}
