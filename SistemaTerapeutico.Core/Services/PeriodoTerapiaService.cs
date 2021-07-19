using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PeriodoTerapiaService : IPeriodoTerapiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PeriodoTerapiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddPeriodoTerapia(PeriodoTerapia periodoTerapia)
        {
            return await _unitOfWork.PeriodoTerapiaRepository.AddReturnId(periodoTerapia);
        }

        public async Task DeletePeriodoTerapia(int idperiodoTerapia)
        {
            await _unitOfWork.PeriodoTerapiaRepository.Delete(idperiodoTerapia);
        }

        public async Task<PeriodoTerapia> GetPeriodoTerapiaById(int idperiodoTerapia)
        {
            return await _unitOfWork.PeriodoTerapiaRepository.GetById(idperiodoTerapia);
        }

        public IEnumerable<PeriodoTerapia> GetPeriodosTerapias()
        {
            return _unitOfWork.PeriodoTerapiaRepository.GetAll();
        }

        public void UpdatePeriodoTerapia(PeriodoTerapia periodoTerapia)
        {
            _unitOfWork.PeriodoTerapiaRepository.Update(periodoTerapia);
        }
        public Task<IEnumerable<PeriodoTerapia>> GetPeriodosTerapiasByIdTipo(int idTipo)
        {
            return _unitOfWork.PeriodoTerapiaRepository.GetTerapiasPeriodosByIdTerapia(idTipo);
        }
    }
}
