using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class AtencionService : IAtencionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtencionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddAtencion(Atencion atencion)
        {
            return _unitOfWork.AtencionRepository.AddReturnId(atencion);
        }

        public async Task DeleteAtencion(int idAtencion)
        {
            await _unitOfWork.AtencionRepository.Delete(idAtencion);
            _unitOfWork.SaveChanges();
        }

        public Task<Atencion> GetAtencionById(int idAtencion)
        {
            return _unitOfWork.AtencionRepository.GetById(idAtencion);
        }

        public IEnumerable<Atencion> GetAtenciones()
        {
            return _unitOfWork.AtencionRepository.GetAll();
        }

        public Task<Atencion> GetLastAtencionByIdParticipante(int idParticipante)
        {
            return _unitOfWork.AtencionRepository.GetLastAtencionByIdParticipante(idParticipante);
        }

        public void UpdateAtencion(Atencion atencion)
        {
            _unitOfWork.AtencionRepository.Update(atencion);
            _unitOfWork.SaveChanges();
        }
    }
}
