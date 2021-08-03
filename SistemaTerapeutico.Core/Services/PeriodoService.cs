using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddPeriodo(Periodo periodo)
        {
            return await _unitOfWork.PeriodoRepository.AddReturnId(periodo);
        }

        public async Task DeletePeriodo(int idPeriodo)
        {
            await _unitOfWork.PeriodoRepository.Delete(idPeriodo);
            _unitOfWork.SaveChanges();
        }

        public async Task<Periodo> GetPeriodoById(int idPeriodo)
        {
            return await _unitOfWork.PeriodoRepository.GetById(idPeriodo);
        }

        public IEnumerable<Periodo> GetPeriodos()
        {
            return _unitOfWork.PeriodoRepository.GetAll();
        }

        public void UpdatePeriodo(Periodo periodo)
        {
            _unitOfWork.PeriodoRepository.Update(periodo);
            _unitOfWork.SaveChanges();
        }
        public Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo)
        {
            return _unitOfWork.PeriodoRepository.GetPeriodosByIdTipo(idTipo);
        }
    }
}
