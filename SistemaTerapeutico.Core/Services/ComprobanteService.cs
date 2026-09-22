using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Services
{
    public class ComprobanteService : IComprobanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComprobanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddComprobante(Comprobante comprobante)
        {
            return _unitOfWork.ComprobanteRepository.AddReturnId(comprobante);
        }

        public async Task DeleteComprobante(int idComprobante)
        {
            await _unitOfWork.ComprobanteRepository.Delete(idComprobante);
            _unitOfWork.SaveChanges();
        }

        public Task<Comprobante> GetComprobanteById(int idComprobante)
        {
            return _unitOfWork.ComprobanteRepository.GetById(idComprobante);
        }

        public IEnumerable<Comprobante> GetsComprobante()
        {
            return _unitOfWork.ComprobanteRepository.GetAll();
        }

        public void UpdateComprobante(Comprobante Comprobante)
        {
            _unitOfWork.ComprobanteRepository.Update(Comprobante);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<ComprobanteResumenView> GetsComprobanteResumenView()
        {
            return _unitOfWork.ComprobanteResumenViewRepository.GetAll();
        }
        public async Task<ComprobanteView> GetComprobanteView(int idComprobante)
        {
            return await _unitOfWork.ComprobanteViewRepository.GetById(idComprobante);
        }
        public IEnumerable<ComprobanteResumenView> GetsComprobanteResumenViewFilter(DateTime? fechaInicio, DateTime? fechaFin, int idTipo, string serie, string numero, string dniCobrador, string cobrador, string dniPagador, string pagador, int idEstadoPago, int idEstado)
        {
            var list = _unitOfWork.ComprobanteResumenViewRepository.GetAll();

            if (fechaInicio != null)
            {
                if (fechaFin != null)
                {
                    list = list.Where(x => DateTime.Parse(x.Fecha.ToShortDateString()) >= fechaInicio && DateTime.Parse(x.Fecha.ToShortDateString()) <= fechaFin);
                }
                else
                {
                    list = list.Where(x => x.Fecha.ToShortDateString() == DateTime.Parse(fechaInicio.ToString()).ToShortDateString());
                }
            }

            if (idTipo > 0)
            {
                list = list.Where(x => x.IdTipo == idTipo);
            }

            if (!string.IsNullOrEmpty(serie))
            {
                list = list.Where(x => x.Serie.Equals(serie));
            }

            if (!string.IsNullOrEmpty(numero))
            {
                list = list.Where(x => x.Numero.Equals(numero));
            }

            if (!string.IsNullOrEmpty(dniCobrador))
            {
                list = list.Where(x => x.DNICobrador.ToLower().Contains(dniCobrador.ToLower()));
            }

            if (!string.IsNullOrEmpty(cobrador))
            {
                list = list.Where(x => x.Cobrador.ToLower().Contains(cobrador.ToLower()));
            }

            if (!string.IsNullOrEmpty(dniPagador))
            {
                list = list.Where(x => x.DNIPagador.ToLower().Contains(dniPagador.ToLower()));
            }

            if (!string.IsNullOrEmpty(pagador))
            {
                list = list.Where(x => x.Pagador.ToLower().Contains(pagador.ToLower()));
            }

            if (idEstadoPago > 0)
            {
                list = list.Where(x => x.IdEstadoPago == idEstadoPago);
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<IEnumerable<ComprobanteDetalleView>> GetsComprobanteDetalleView(int idComprobante)
        {
            return await _unitOfWork.ComprobanteDetalleViewRepository.GetsById(idComprobante);
        }
        public async Task DeleteComprobanteDetalle(int idComprobante, int numero)
        {
            await _unitOfWork.ComprobanteDetalleRepository.DeleteByIdsAndSave(idComprobante, numero);
        }
        public async Task<IEnumerable<ComprobantePagoView>> GetsComprobantePagoView(int idComprobante)
        {
            return await _unitOfWork.ComprobantePagoViewRepository.GetsById(idComprobante);
        }
        public async Task DeleteComprobantePago(int idComprobante, int numero)
        {
            await _unitOfWork.ComprobantePagoRepository.DeleteByIdsAndSave(idComprobante, numero);
        }
        public async Task<int> AddUpdateComprobanteWithDetails(ComprobanteDto comprobanteDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (comprobanteDto.Id == 0)
            {
                Comprobante comprobante = new Comprobante()
                {
                    Fecha = comprobanteDto.Fecha,
                    IdTipo = comprobanteDto.IdTipo,
                    Serie = comprobanteDto.Serie,
                    Numero = comprobanteDto.Numero,
                    IdCobrador = comprobanteDto.IdCobrador,
                    IdPagador = comprobanteDto.IdPagador,
                    Observaciones = comprobanteDto.Observaciones ?? "",
                    IdMoneda = comprobanteDto.IdMoneda,
                    TipoCambio = comprobanteDto.TipoCambio,
                    MontoTotal = comprobanteDto.MontoTotal,
                    MontoSaldo = comprobanteDto.MontoSaldo,
                    IdEstadoPago = comprobanteDto.IdEstadoPago,
                    IdEstado = comprobanteDto.IdEstado,
                };

                comprobante.UsuarioRegistro = usuario;

                id = await _unitOfWork.ComprobanteRepository.AddReturnId(comprobante);
                comprobante.Id = id;
            }
            else
            {
                id = comprobanteDto.Id;

                Comprobante comprobante = await _unitOfWork.ComprobanteRepository.GetById(id);

                comprobante.Fecha = comprobanteDto.Fecha;
                comprobante.IdTipo = comprobanteDto.IdTipo;
                comprobante.Serie = comprobanteDto.Serie;
                comprobante.Numero = comprobanteDto.Numero;
                comprobante.IdCobrador = comprobanteDto.IdCobrador;
                comprobante.IdPagador = comprobanteDto.IdPagador;
                comprobante.Observaciones = comprobanteDto.Observaciones ?? "";
                comprobante.IdMoneda = comprobanteDto.IdMoneda;
                comprobante.TipoCambio = comprobanteDto.TipoCambio;
                comprobante.MontoTotal = comprobanteDto.MontoTotal;
                comprobante.MontoSaldo = comprobanteDto.MontoSaldo;
                comprobante.IdEstadoPago = comprobanteDto.IdEstadoPago;
                comprobante.IdEstado = comprobanteDto.IdEstado;
                comprobante.FechaModificacion = DateTime.Now;
                comprobante.UsuarioModificacion = usuario;

                _unitOfWork.ComprobanteRepository.UpdateAndSave(comprobante);
            }

            foreach (var item in comprobanteDto.ComprobanteDetalle)
            {
                if (item.Id == 0)
                {
                    if (item.IdConceptoCobro > 0)
                    {
                        await _unitOfWork.ComprobanteDetalleRepository.AddGenerateIdTwo(new ComprobanteDetalle()
                        {
                            Id = id,
                            Cantidad = item.Cantidad,
                            CantidadStock = item.CantidadStock,
                            IdConceptoCobro = item.IdConceptoCobro,
                            PrecioUnitario = item.PrecioUnitario,
                            SubTotal = item.SubTotal,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    ComprobanteDetalle comprobanteDetalle = await _unitOfWork.ComprobanteDetalleRepository.GetByIds(id, item.Numero);

                    comprobanteDetalle.Cantidad = item.Cantidad;
                    comprobanteDetalle.CantidadStock = item.CantidadStock;
                    comprobanteDetalle.IdConceptoCobro = item.IdConceptoCobro;
                    comprobanteDetalle.PrecioUnitario = item.PrecioUnitario;
                    comprobanteDetalle.SubTotal = item.SubTotal;
                    comprobanteDetalle.FechaModificacion = DateTime.Now;
                    comprobanteDetalle.UsuarioModificacion = usuario;

                    _unitOfWork.ComprobanteDetalleRepository.UpdateAndSave(comprobanteDetalle);
                }
            }

            foreach (var item in comprobanteDto.ComprobantePago)
            {
                if (item.Id == 0)
                {
                    if (item.IdEntidadPago > 0)
                    {
                        await _unitOfWork.ComprobantePagoRepository.AddGenerateIdTwo(new ComprobantePago()
                        {
                            Id = id,
                            IdMedioPago = item.IdMedioPago,
                            IdEntidadPago = item.IdEntidadPago,
                            NumeroCuenta = item.NumeroCuenta,
                            NumeroOperacion = item.NumeroOperacion,
                            NumeroVoucher = item.NumeroVoucher,
                            FechaPago = item.FechaPago,
                            IdMoneda = item.IdMoneda,
                            TipoCambio = item.TipoCambio,
                            Monto = item.Monto,
                            Observaciones = item.Observaciones,
                            IdEstado = item.IdEstado,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    ComprobantePago comprobantePago = await _unitOfWork.ComprobantePagoRepository.GetByIds(id, item.Numero);

                    comprobantePago.IdMedioPago = item.IdMedioPago;
                    comprobantePago.IdEntidadPago = item.IdEntidadPago;
                    comprobantePago.NumeroCuenta = item.NumeroCuenta;
                    comprobantePago.NumeroOperacion = item.NumeroOperacion;
                    comprobantePago.NumeroVoucher = item.NumeroVoucher;
                    comprobantePago.FechaPago = item.FechaPago;
                    comprobantePago.IdMoneda = item.IdMoneda;
                    comprobantePago.TipoCambio = item.TipoCambio;
                    comprobantePago.Monto = item.Monto;
                    comprobantePago.Observaciones = item.Observaciones;
                    comprobantePago.IdEstado = item.IdEstado;
                    comprobantePago.FechaModificacion = DateTime.Now;
                    comprobantePago.UsuarioModificacion = usuario;

                    _unitOfWork.ComprobantePagoRepository.UpdateAndSave(comprobantePago);
                }
            }

            return id;
        }
        public async Task AnnulComprobante(int idComprobante)
        {
            Comprobante entity = await _unitOfWork.ComprobanteRepository.GetById(idComprobante);

            entity.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.ComprobanteRepository.UpdateAndSave(entity);
        }
        public async Task ActiveComprobante(int idComprobante)
        {
            Comprobante entity = await _unitOfWork.ComprobanteRepository.GetById(idComprobante);

            entity.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.ComprobanteRepository.UpdateAndSave(entity);
        }
    }
}
