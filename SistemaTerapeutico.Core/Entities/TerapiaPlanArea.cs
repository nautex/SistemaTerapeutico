using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPlanArea : BaseEntityTwoIds
    {
        public int IdArea { get; set; }
        public int Orden { get; set; }
    }
}
