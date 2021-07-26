using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPeriodo : BaseEntityTwoIds
    {
        public TerapiaPeriodo(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdEstadoPago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
