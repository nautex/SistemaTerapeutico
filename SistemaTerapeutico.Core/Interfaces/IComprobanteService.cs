using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IComprobanteService
    {
        Task<int> AddComprobante(Comprobante comprobante);
        Task DeleteComprobante(int idComprobante);
        Task<Comprobante> GetComprobanteById(int idComprobante);
        IEnumerable<Comprobante> GetsComprobante();
        void UpdateComprobante(Comprobante Comprobante);
        IEnumerable<ComprobanteResumenView> GetsComprobanteResumenView();
        Task<ComprobanteView> GetComprobanteView(int idComprobante);
        IEnumerable<ComprobanteResumenView> GetsComprobanteResumenViewFilter(DateTime? fechaInicio, DateTime? fechaFin, int idTipo, string serie, string numero, string dniCobrador, string cobrador, string dniPagador, string pagador, int idEstadoPago, int idEstado);
        Task<IEnumerable<ComprobanteDetalleView>> GetsComprobanteDetalleView(int idComprobante);
        Task DeleteComprobanteDetalle(int idComprobante, int numero);
        Task<IEnumerable<ComprobantePagoView>> GetsComprobantePagoView(int idComprobante);
        Task DeleteComprobantePago(int idComprobante, int numero);
        Task<int> AddUpdateComprobanteWithDetails(ComprobanteDto comprobanteDto);
        Task AnnulComprobante(int idComprobante);
        Task ActiveComprobante(int idComprobante);
    }
}
