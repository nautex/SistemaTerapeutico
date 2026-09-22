using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class FilialService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public FilialService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<FilialView> GetALl()
        {
            //return _unitOfWork.FilialViewRepository.GetAll();
            return _context.GetAll<FilialView>();
        }
        public IEnumerable<Lista> GetsList()
        {
            var list = _context.GetAll<FilialView>();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query;
        }
    }
}
