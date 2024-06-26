﻿using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteRepository : BaseEntityRepository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(SISDETContext context) : base(context)
        {

        }
    }
}
