using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPlanificacion : BaseEntityTwoIds
    {
        public TerapiaPlanificacion()
        {

        }
        public string DetalleResultado { get; set; }
    }
}
