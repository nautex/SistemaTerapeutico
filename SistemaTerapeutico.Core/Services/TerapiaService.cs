using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaService : ITerapiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddTerapia(Terapia terapia)
        {
            return _unitOfWork.TerapiaRepository.AddReturnId(terapia);
        }

        public async Task DeleteTerapia(int idTerapia)
        {
            await _unitOfWork.TerapiaRepository.Delete(idTerapia);
            _unitOfWork.SaveChanges();
        }

        public Task<Terapia> GetTerapiaById(int idTerapia)
        {
            return _unitOfWork.TerapiaRepository.GetById(idTerapia);
        }

        public IEnumerable<Terapia> GetTerapias()
        {
            return _unitOfWork.TerapiaRepository.GetAll();
        }

        public void UpdateTerapia(Terapia terapia)
        {
            _unitOfWork.TerapiaRepository.Update(terapia);
            _unitOfWork.SaveChanges();
        }
    }
}
