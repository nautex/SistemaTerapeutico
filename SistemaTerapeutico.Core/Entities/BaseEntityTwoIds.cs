﻿namespace SistemaTerapeutico.Core.Entities
{
    public class BaseEntityTwoIds : BaseEntity
    {
        public BaseEntityTwoIds(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int Numero { get; set; }
    }
}