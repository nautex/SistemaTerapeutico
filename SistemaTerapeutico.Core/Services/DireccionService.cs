using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DireccionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddDireccion(Direccion direccion)
        {
            return await _unitOfWork.DireccionRepository.AddReturnId(direccion);
        }

        public async Task DeleteDireccion(int idDireccion)
        {
            await _unitOfWork.DireccionRepository.Delete(idDireccion);
        }

        public async Task<Direccion> GetDireccionById(int idDireccion)
        {
            return await _unitOfWork.DireccionRepository.GetById(idDireccion);
        }

        public IEnumerable<Direccion> GetDirecciones()
        {
            return _unitOfWork.DireccionRepository.GetAll();
        }

        public async Task<IEnumerable<Direccion>> GetDireccionsByUbigeoYDetalle(int idUbigeo, string detalle)
        {
            return await _unitOfWork.DireccionRepository.GetDireccionesByUbigeoYDetalle(idUbigeo, detalle);
        }

        public void UpdateDireccion(Direccion direccion)
        {
            _unitOfWork.DireccionRepository.Update(direccion);
        }
    }
}
