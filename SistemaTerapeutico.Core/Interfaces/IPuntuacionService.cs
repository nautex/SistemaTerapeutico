using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPuntuacionService
    {
        Task<int> AddPuntuacionGrupo(PuntuacionGrupo PuntuacionGrupo);
        Task DeletePuntuacionGrupo(int idPuntuacionGrupo);
        Task<PuntuacionGrupo> GetPuntuacionGrupo(int idPuntuacionGrupo);
        IEnumerable<PuntuacionGrupo> GetsPuntuacionGrupo();
        void UpdatePuntuacionGrupo(PuntuacionGrupo sesion);
    }
}
