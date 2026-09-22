using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanAreaDto : BaseEntityTwoIds
    {
        public int IdArea { get; set; }
        public int Orden { get; set; }
    }
}
