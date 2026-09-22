using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteNivelLenguajeRepository : BaseEntity2IdsRepository<ParticipanteNivelLenguaje>, IParticipanteNivelLenguajeRepository
    {
        public ParticipanteNivelLenguajeRepository(SISDETContext context) : base(context)
        {
        }
    }
}
