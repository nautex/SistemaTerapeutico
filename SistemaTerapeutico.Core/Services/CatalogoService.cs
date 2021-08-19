using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatalogoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Catalogo>> GetCatalogosByIdPadre(int idPadre)
        {
            return await _unitOfWork.CatalogoRepository.GetCatalogosByIdPadre(idPadre);
        }
        public async Task<IEnumerable<Lista>> GetCatalogosByIdPadreInLista(int idPadre)
        {
            return await _unitOfWork.CatalogoRepository.GetCatalogosByIdPadreInLista(idPadre);
        }
    }
}
