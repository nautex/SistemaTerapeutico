using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IServicioService
    {
        IEnumerable<Servicio> GetAll();
        IEnumerable<Lista> GetsListServicio();
        Task<TarifaView> GetTarifaView(int idTarifa);
        IEnumerable<Lista> GetsListTarifa();
        IEnumerable<TarifaView> GetsTarifaView(int idServicio, int idLocal, int idTipo, int sesionesMes, int idEstado);
        Task<int> AddTarifa(Tarifa Tarifa);
        Task DeleteTarifa(int idTarifa);
        Task<Tarifa> GetTarifaById(int idTarifa);
        IEnumerable<Tarifa> GetTarifas();
        void UpdateTarifa(Tarifa Tarifa);
        Task AnnulTarifa(int idTarifa);
        Task ActiveTarifa(int idTarifa);
        Task<int> AddUpdateTarifa(TarifaViewDto tarifaViewDto);
    }
}
