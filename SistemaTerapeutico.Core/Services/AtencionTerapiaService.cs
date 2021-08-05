using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class AtencionTerapiaService : IAtencionTerapiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AtencionTerapiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAtencionTerapia(AtencionTerapia atencionTerapia)
        {
            await _unitOfWork.AtencionTerapiaRepository.Add(atencionTerapia);
            _unitOfWork.SaveChanges();
        }

        public void DeleteAtencionesTerapiasByIdAtencion(int idAtencion)
        {
            _unitOfWork.AtencionTerapiaRepository.DeletesById(idAtencion);
        }

        public void DeleteAtencionTerapiaByIds(int idAtencion, int idTerapia)
        {
            _unitOfWork.AtencionTerapiaRepository.DeleteByIds(idAtencion, idTerapia);
        }

        public IEnumerable<AtencionTerapia> GetAtencionesTerapias()
        {
            return _unitOfWork.AtencionTerapiaRepository.GetAll();
        }

        public async Task<IEnumerable<AtencionTerapia>> GetAtencionesTerapiasByIdAtencion(int idAtencion)
        {
            return await _unitOfWork.AtencionTerapiaRepository.GetsById(idAtencion);
        }

        public void UpdateAtencionTerapia(AtencionTerapia atencionTerapia)
        {
            _unitOfWork.AtencionTerapiaRepository.Update(atencionTerapia);
        }
    }
}
