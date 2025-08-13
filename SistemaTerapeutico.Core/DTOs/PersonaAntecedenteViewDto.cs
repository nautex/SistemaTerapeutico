using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaAntecedenteViewDto : BaseEntity2Ids
    {
        public int IdAntecedente { get; set; }
        public string Antecedente { get; set; }
    }
}
