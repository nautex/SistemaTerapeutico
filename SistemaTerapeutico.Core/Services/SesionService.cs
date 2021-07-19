using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class SesionService : ISesionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddSesion(Sesion Sesion)
        {
            return _unitOfWork.SesionRepository.AddReturnId(Sesion);
        }

        public Task DeleteSesion(int idSesion)
        {
            return _unitOfWork.SesionRepository.Delete(idSesion);
        }

        public async Task<Sesion> GetSesionById(int idSesion)
        {
            return await _unitOfWork.SesionRepository.GetById(idSesion);
        }

        public IEnumerable<Sesion> GetSesiones()
        {
            return _unitOfWork.SesionRepository.GetAll();
        }

        public async Task<IEnumerable<Sesion>> GetSesionesByIdPeriodoTerapia(int idPeriodoTerapia)
        {
            return await _unitOfWork.SesionRepository.GetSesionesByIdPeriodoTerapia(idPeriodoTerapia);
        }

        public async Task<IEnumerable<Sesion>> GetSesionesByIdTerapia(int idTerapia)
        {
            return await _unitOfWork.SesionRepository.GetSesionesByIdTerapia(idTerapia);
        }

        public void UpdateSesion(Sesion sesion)
        {
            _unitOfWork.SesionRepository.Update(sesion);
        }
    }
}
