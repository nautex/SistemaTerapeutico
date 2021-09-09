using System;

namespace SistemaTerapeutico.Core.Entities
{
    public class AtencionTerapia : BaseEntityTwoIds
    {
        public AtencionTerapia()
        {
            FechaRegistro = DateTime.Now;
        }
    }
}
