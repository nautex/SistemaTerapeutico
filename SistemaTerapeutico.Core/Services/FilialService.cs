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
    public class FilialService : IFilialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FilialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<FilialView> GetALl()
        {
            return _unitOfWork.FilialViewRepository.GetAll();
        }
        public IEnumerable<Lista> GetsList()
        {
            var list = _unitOfWork.FilialViewRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query;
        }
    }
}
