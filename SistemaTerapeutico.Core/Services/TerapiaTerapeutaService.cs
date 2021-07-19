using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaTerapeutaService : ITerapiaTerapeutaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaTerapeutaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddTerapiaTerapeuta(TerapiaTerapeuta terapiaTerapeuta)
        {
            await _unitOfWork.TerapiaTerapeutaRepository.Add(terapiaTerapeuta);
        }

        public void DeleteTerapiasTerapeutasByIdAtencion(int idAtencion)
        {
            _unitOfWork.TerapiaTerapeutaRepository.DeletesById(idAtencion);
        }

        public void DeleteTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TerapiaTerapeuta> GetTerapiasTerapeutas()
        {
            return _unitOfWork.TerapiaTerapeutaRepository.GetAll();
        }

        public async Task<IEnumerable<TerapiaTerapeuta>> GetTerapiasTerapeutasByIdAtencion(int idAtencion)
        {
            return await _unitOfWork.TerapiaTerapeutaRepository.GetsById(idAtencion);
        }

        public Task<TerapiaTerapeuta> GetTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta)
        {
            throw new NotImplementedException();
        }

        public void UpdateTerapiaTerapeuta(TerapiaTerapeuta terapiaTerapeuta)
        {
            throw new NotImplementedException();
        }
    }
}
