using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class SalonService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public SalonService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<SalonView> GetAll()
        {
            return _context.GetAll<SalonView>();
        }
        public IEnumerable<Lista> GetsListByIdFilial(int idFilial)
        {
            var list = _context.GetAll<SalonView>();

            list = list.Where(x => x.Id == idFilial);

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Codigo };

            return query;
        }
    }
}
