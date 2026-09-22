using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IParticipanteNivelLenguajeViewRepository : IBaseRepositoryView<ParticipanteNivelLenguajeView>
    {
        Task<IEnumerable<ParticipanteNivelLenguajeView>> GetsById(int id);
    }
}
