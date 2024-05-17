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
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Servicio> GetAll()
        {
            return _unitOfWork.ServicioRepository.GetAll();
        }
        public IEnumerable<Lista> GetsListServicio()
        {
            var list = _unitOfWork.ServicioRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public IEnumerable<TarifaView> GetsTarifa()
        {
            return _unitOfWork.TarifaViewRepository.GetAll();
        }
        public IEnumerable<Lista> GetsListTarifa()
        {
            var list = _unitOfWork.TarifaViewRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public IEnumerable<TarifaView> GetsTarifaByIdServicioOrIdLocalOrIdTipoOrSesionesMes(int idServicio, int idLocal, int idTipo, int sesionesMes)
        {
            var list = _unitOfWork.TarifaViewRepository.GetAll();

            if (idServicio > 0)
            {
                list = list.Where(x => x.IdServicio == idServicio);
            }

            if (idLocal > 0)
            {
                list = list.Where(x => x.IdLocal == idLocal);
            }

            if (idTipo > 0)
            {
                list = list.Where(x => x.IdTipo == idTipo);
            }

            if (sesionesMes > 0)
            {
                list = list.Where(x => x.SesionesMes == sesionesMes);
            }

            return list.ToList();
        }
    }
}
