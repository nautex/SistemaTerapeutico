using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class UbigeoViewService : IUbigeoViewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UbigeoViewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Lista>> GetDepartamentosByIdPais(int idPais)
        {
            return await _unitOfWork.UbigeoViewRepository.GetDepartamentosByIdPais(idPais);
        }

        public async Task<IEnumerable<Lista>> GetPaises()
        {
            return await _unitOfWork.UbigeoViewRepository.GetPaises();
        }

        public async Task<IEnumerable<Lista>> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            return await _unitOfWork.UbigeoViewRepository.GetProvinciasByIdDepartamento(idDepartamento);
        }

        public async Task<IEnumerable<Lista>> GetUbigeosByIdProvincia(int idProvincia)
        {
            return await _unitOfWork.UbigeoViewRepository.GetUbigeosByIdProvincia(idProvincia);
        }

        public async Task<UbigeoView> GetUbigeoViewById(int id)
        {
            return await _unitOfWork.UbigeoViewRepository.GetById(id);
        }
    }
}
