using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteNivelLenguajeViewRepository : BaseEntity2IdsRepository<ParticipanteNivelLenguajeView>, IParticipanteNivelLenguajeViewRepository
    {
        public ParticipanteNivelLenguajeViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
