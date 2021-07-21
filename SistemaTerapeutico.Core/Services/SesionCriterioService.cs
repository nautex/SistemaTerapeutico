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

        public async Task DeleteSesionCriterio(int idSesionCriterio)
        {
            await _unitOfWork.SesionCriterioRepository.Delete(idSesionCriterio);
        }

        public async Task<SesionCriterio> GetSesionCriterioById(int idSesionCriterio)
        {
            return await _unitOfWork.SesionCriterioRepository.GetById(idSesionCriterio);
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
