using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaHorario : BaseEntity2Ids
    {
        public int DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
    }
}
