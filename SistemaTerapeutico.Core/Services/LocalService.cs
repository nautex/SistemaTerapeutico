using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Services
{
    public class LocalService : ILocalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<LocalView> GetALl()
        {
            return _unitOfWork.LocalViewRepository.GetAll();
        }
        public IEnumerable<Lista> GetsList()
        {
            var list = _unitOfWork.LocalViewRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query;
        }
    }
}
