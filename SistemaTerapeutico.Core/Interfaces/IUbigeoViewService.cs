using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUbigeoViewService
    {
        Task<UbigeoView> GetUbigeoViewById(int id);
        Task<IEnumerable<Lista>> GetPaises();
        Task<IEnumerable<Lista>> GetDepartamentosByIdPais(int idPais);
        Task<IEnumerable<Lista>> GetProvinciasByIdDepartamento(int idDepartamento);
        Task<IEnumerable<Lista>> GetUbigeosByIdProvincia(int idProvincia);
    }
}
