using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPlanificacionCriterio : BaseEntityThreeIds
    {
        public TerapiaPlanificacionCriterio()
        {

        }
        public int Orden { get; set; }
        public int IdPuntuacionDetalle { get; set; }
    }
}
