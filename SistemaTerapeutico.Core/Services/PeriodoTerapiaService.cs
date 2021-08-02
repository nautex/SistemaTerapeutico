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
        public async Task<int> AddPeriodoTerapia(Periodo periodoTerapia)
        {
            return await _unitOfWork.PeriodoTerapiaRepository.AddReturnId(periodoTerapia);
        }

        public async Task DeletePeriodoTerapia(int idperiodoTerapia)
        {
            await _unitOfWork.PeriodoTerapiaRepository.Delete(idperiodoTerapia);
            _unitOfWork.SaveChanges();
        }

        public async Task<Periodo> GetPeriodoTerapiaById(int idperiodoTerapia)
        {
            return await _unitOfWork.PeriodoTerapiaRepository.GetById(idperiodoTerapia);
        }

        public IEnumerable<Periodo> GetPeriodosTerapias()
        {
            return _unitOfWork.PeriodoTerapiaRepository.GetAll();
        }

        public void UpdatePeriodoTerapia(Periodo periodoTerapia)
        {
            _unitOfWork.PeriodoTerapiaRepository.Update(periodoTerapia);
            _unitOfWork.SaveChanges();
        }
        public Task<IEnumerable<Periodo>> GetPeriodosTerapiasByIdTipo(int idTipo)
        {
            return _unitOfWork.PeriodoTerapiaRepository.GetTerapiasPeriodosByIdTerapia(idTipo);
        }
    }
}
