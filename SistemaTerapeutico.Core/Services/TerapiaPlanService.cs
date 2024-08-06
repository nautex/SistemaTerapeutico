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
    public class TerapiaPlanService : ITerapiaPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaPlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddTerapiaPlan(TerapiaPlan terapiaPlan)
        {
            return _unitOfWork.TerapiaPlanRepository.AddReturnId(terapiaPlan);
        }

        public async Task DeleteTerapiaPlan(int idTerapiaPlan)
        {
            await _unitOfWork.TerapiaPlanRepository.Delete(idTerapiaPlan);
            _unitOfWork.SaveChanges();
        }

        public Task<TerapiaPlan> GetTerapiaPlan(int idTerapiaPlan)
        {
            return _unitOfWork.TerapiaPlanRepository.GetById(idTerapiaPlan);
        }

        public IEnumerable<TerapiaPlan> GetsTerapiaPlan()
        {
            return _unitOfWork.TerapiaPlanRepository.GetAll();
        }

        public void UpdateTerapiaPlan(TerapiaPlan terapiaPlan)
        {
            _unitOfWork.TerapiaPlanRepository.Update(terapiaPlan);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenViewAll()
        {
            return _unitOfWork.TerapiaPlanResumenViewRepository.GetAll();
        }
        public async Task<TerapiaPlanView> GetTerapiaPlanView(int idTerapiaPlan)
        {
            return await _unitOfWork.TerapiaPlanViewRepository.GetById(idTerapiaPlan);
        }
        public IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenView(int idLocal, string member, string therapist, int idEstadoVigencia, int idEstado)
        {
            var list = _unitOfWork.TerapiaPlanResumenViewRepository.GetAll();

            if (idLocal > 0)
            {
                list = list.Where(x => x.IdLocal == idLocal);
            }

            if (!string.IsNullOrEmpty(member))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(member.ToLower()));
            }

            if (!string.IsNullOrEmpty(therapist))
            {
                list = list.Where(x => x.Terapeuta.ToLower().Contains(therapist.ToLower()));
            }

            if (idEstadoVigencia > 0)
            {
                list = list.Where(x => x.IdEstadoVigencia == idEstadoVigencia || x.IdEstadoVigencia == null);
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado || x.IdEstado == null);
            }

            return list.ToList();
        }
        public async Task<IEnumerable<TerapiaPlanAreaView>> GetsTerapiaPlanAreaView(int idTerapiaPlan)
        {
            return await _unitOfWork.TerapiaPlanAreaViewRepository.GetsById(idTerapiaPlan);
        }
        public IEnumerable<Area> GetsArea(int idTerapia)
        {
            return _unitOfWork.TerapiaPlanAreaViewRepository.GetsArea(idTerapia);
        }
        public async Task DeleteTerapiaPlanArea(int idTerapiaPlan, int numero)
        {
            await _unitOfWork.TerapiaPlanAreaRepository.DeleteByIdsAndSave(idTerapiaPlan, numero);
        }
        public async Task<int> AddUpdateTerapiaPlanWithDetails(TerapiaPlanDto terapiaPlanDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (terapiaPlanDto.Id == 0)
            {
                TerapiaPlan terapiaPlan = new TerapiaPlan()
                {
                    IdTerapia = terapiaPlanDto.IdTerapia,
                    IdPeriodo = terapiaPlanDto.IdPeriodo,
                    FechaInicio = terapiaPlanDto.FechaInicio,
                    IdEstadoVigencia = terapiaPlanDto.IdEstadoVigencia,
                    IdEstado = terapiaPlanDto.IdEstado,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.TerapiaPlanRepository.AddReturnId(terapiaPlan);
                terapiaPlan.Id = id;
            }
            else
            {
                id = terapiaPlanDto.Id;

                TerapiaPlan terapiaPlan = await _unitOfWork.TerapiaPlanRepository.GetById(id);

                terapiaPlan.IdTerapia = terapiaPlanDto.IdTerapia;
                terapiaPlan.IdPeriodo = terapiaPlanDto.IdPeriodo;
                terapiaPlan.FechaInicio = terapiaPlanDto.FechaInicio;
                terapiaPlan.IdEstadoVigencia = terapiaPlanDto.IdEstadoVigencia;
                terapiaPlan.IdEstado = terapiaPlanDto.IdEstado;
                terapiaPlan.FechaModificacion = DateTime.Now;
                terapiaPlan.UsuarioModificacion = usuario;

                _unitOfWork.TerapiaPlanRepository.UpdateAndSave(terapiaPlan);
            }

            foreach (var item in terapiaPlanDto.TerapiaPlanArea)
            {
                if (item.Id == 0)
                {
                    if (item.IdArea > 0)
                    {
                        await _unitOfWork.TerapiaPlanAreaRepository.AddGenerateIdTwo(new TerapiaPlanArea()
                        {
                            Id = id,
                            IdArea = item.IdArea,
                            Orden = item.Orden,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaPlanArea terapiaPlanTerapeuta = await _unitOfWork.TerapiaPlanAreaRepository.GetByIds(id, item.Numero);

                    terapiaPlanTerapeuta.IdArea = item.IdArea;
                    terapiaPlanTerapeuta.Orden = item.Orden;
                    terapiaPlanTerapeuta.FechaModificacion = DateTime.Now;
                    terapiaPlanTerapeuta.UsuarioModificacion = usuario;

                    _unitOfWork.TerapiaPlanAreaRepository.UpdateAndSave(terapiaPlanTerapeuta);
                }
            }

            return id;
        }
        public async Task AnnulTerapiaPlan(int idTerapiaPlan)
        {
            TerapiaPlan entity = await _unitOfWork.TerapiaPlanRepository.GetById(idTerapiaPlan);

            entity.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.TerapiaPlanRepository.UpdateAndSave(entity);
        }
        public async Task ActiveTerapiaPlan(int idTerapiaPlan)
        {
            TerapiaPlan entity = await _unitOfWork.TerapiaPlanRepository.GetById(idTerapiaPlan);

            entity.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.TerapiaPlanRepository.UpdateAndSave(entity);
        }
    }
}
