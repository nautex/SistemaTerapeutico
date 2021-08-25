using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

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
            _unitOfWork.SaveChanges();
        }

        public async Task<Direccion> GetDireccionById(int idDireccion)
        {
            return await _unitOfWork.DireccionRepository.GetById(idDireccion);
        }

        public IEnumerable<Direccion> GetDirecciones()
        {
            return _unitOfWork.DireccionRepository.GetAll();
        }

        public IEnumerable<DireccionView> GetDireccionesViewByUbigeoYDetalle(int idUbigeo, string detalle)
        {
            IEnumerable<DireccionView> list = _unitOfWork.DireccionViewRepository.GetAll();

            if (idUbigeo > 0)
            {
                list = list.Where(x => x.IdUbigeo == idUbigeo);
            }

            if (!String.IsNullOrEmpty(detalle))
            {
                list = list.Where(x => x.Detalle.ToLower().Contains(detalle.ToLower()));
            }

            return list.ToList();
        }

        public void UpdateDireccion(Direccion direccion)
        {
            _unitOfWork.DireccionRepository.Update(direccion);
            _unitOfWork.SaveChanges();
        }
    }
}
