using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUbigeoViewRepository : IBaseRepository<UbigeoView>
    {
        Task<IEnumerable<Lista>> GetPaises();
        Task<IEnumerable<Lista>> GetDepartamentosByIdPais(int idPais);
        Task<IEnumerable<Lista>> GetProvinciasByIdDepartamento(int idDepartamento);
        Task<IEnumerable<Lista>> GetUbigeosByIdProvincia(int idProvincia);
    }
}
//123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100