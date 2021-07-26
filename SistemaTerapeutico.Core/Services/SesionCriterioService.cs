using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class SesionCriterioService : ISesionCriterioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionCriterioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddSesionCriterio(SesionCriterio sesionCriterio)
        {
            return _unitOfWork.SesionCriterioRepository.AddReturnId(sesionCriterio);
        }

        public async Task DeleteSesionCriterioByIds(int idSesion, int idObjetivoCriterio)
        {
            await _unitOfWork.SesionCriterioRepository.DeleteByIds(idSesion, idObjetivoCriterio);
        }

        public async Task<SesionCriterio> GetSesionCriterioByIds(int idSesion)
        {
            return await _unitOfWork.SesionCriterioRepository.GetById(idSesion);
        }

        public async Task<SesionCriterio> GetSesionCriterioByIds(int idSesion, int idObjetivoCriterio)
        {
            return await _unitOfWork.SesionCriterioRepository.GetByIds(idSesion, idObjetivoCriterio);
        }

        public IEnumerable<SesionCriterio> GetSesionesCriterios()
        {
            return _unitOfWork.SesionCriterioRepository.GetAll();
        }

        public Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion)
        {
            return _unitOfWork.SesionCriterioRepository.GetSesionesCriteriosByIdSesion(idSesion);
        }

        public void UpdateSesionCriterio(SesionCriterio sesionCriterio)
        {
            _unitOfWork.SesionCriterioRepository.Update(sesionCriterio);
        }
    }
}
