using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SistemaTerapeutico.Core.Services
{
    public class SalonService : ISalonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SalonView> GetAll()
        {
            return _unitOfWork.SalonViewRepository.GetAll();
        }
        public IEnumerable<Lista> GetsListByIdLocal(int idLocal)
        {
            var list = _unitOfWork.SalonViewRepository.GetAll();

            list = list.Where(x => x.IdLocal == idLocal);

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Codigo };

            return query;
        }
    }
}
