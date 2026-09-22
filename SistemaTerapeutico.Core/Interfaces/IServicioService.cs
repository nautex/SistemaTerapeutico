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
        Task<ConceptoCobroView> GetConceptoCobroView(int idTarifa);
        IEnumerable<Lista> GetsListConceptoCobro();
        IEnumerable<ConceptoCobroView> GetsConceptoCobroView(int idServicio, int idFilial, int idTipo, int sesionesMes, int idEstado);
        Task<int> AddConceptoCobro(ConceptoCobro Tarifa);
        Task DeleteConceptoCobro(int idTarifa);
        Task<ConceptoCobro> GetConceptoCobroById(int idTarifa);
        IEnumerable<ConceptoCobro> GetsConceptoCobro();
        void UpdateConceptoCobro(ConceptoCobro Tarifa);
        Task AnnulConceptoCobro(int idTarifa);
        Task ActiveConceptoCobro(int idTarifa);
        Task<int> AddUpdateConceptoCobro(ConceptoCobroViewDto tarifaViewDto);
    }
}
