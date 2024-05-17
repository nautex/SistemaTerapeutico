using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IServicioService
    {
        IEnumerable<Servicio> GetAll();
        IEnumerable<Lista> GetsListServicio();
        IEnumerable<TarifaView> GetsTarifa();
        IEnumerable<Lista> GetsListTarifa();
        IEnumerable<TarifaView> GetsTarifaByIdServicioOrIdLocalOrIdTipoOrSesionesMes(int idServicio, int idLocal, int idTipo, int sesionesMes);
    }
}
