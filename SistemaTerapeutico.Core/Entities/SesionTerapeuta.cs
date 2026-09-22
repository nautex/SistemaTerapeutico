using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class SesionTerapeuta : BaseEntityTwoIds
    {
        public int IdTerapeuta { get; set; }
        public int IdTipoCargo { get; set; }
    }
}
