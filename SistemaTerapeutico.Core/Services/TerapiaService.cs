using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaService : ITerapiaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddTerapia(Terapia terapia)
        {
            return _unitOfWork.TerapiaRepository.AddReturnId(terapia);
        }

        public async Task DeleteTerapia(int idTerapia)
        {
            await _unitOfWork.TerapiaRepository.Delete(idTerapia);
            _unitOfWork.SaveChanges();
        }

        public Task<Terapia> GetTerapiaById(int idTerapia)
        {
            return _unitOfWork.TerapiaRepository.GetById(idTerapia);
        }

        public IEnumerable<Terapia> GetTerapias()
        {
            return _unitOfWork.TerapiaRepository.GetAll();
        }

        public void UpdateTerapia(Terapia terapia)
        {
            _unitOfWork.TerapiaRepository.Update(terapia);
            _unitOfWork.SaveChanges();
        }
        public IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewAll()
        {
            return _unitOfWork.TerapiaResumenViewRepository.GetAll();
        }
        public async Task<TerapiaView> GetTerapiaView(int idTerapia)
        {
            return await _unitOfWork.TerapiaViewRepository.GetById(idTerapia);
        }
        public IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewByLocalOrMemberOrTherapist(string local, string member, string therapist)
        {
            var list =  _unitOfWork.TerapiaResumenViewRepository.GetAll();

            if (!string.IsNullOrEmpty(local))
            {
                list = list.Where(x => x.Local.ToLower().Contains(local.ToLower()));
            }

            if (!string.IsNullOrEmpty(member))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(member.ToLower()));
            }

            if (!string.IsNullOrEmpty(therapist))
            {
                list = list.Where(x => x.Terapeutas.ToLower().Contains(therapist.ToLower()));
            }

            return list.ToList();
        }
        public async Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioView(int idTerapia)
        {
            return await _unitOfWork.TerapiaHorarioViewRepository.GetsById(idTerapia);
        }
        public async Task<IEnumerable<TerapiaTerapeutaView>> GetsTerapiaTerapeutaView(int idTerapia)
        {
            return await _unitOfWork.TerapiaTerapeutaViewRepository.GetsById(idTerapia);
        }
        public async Task<IEnumerable<TerapiaParticipanteView>> GetsTerapiaParticipanteView(int idTerapia)
        {
            return await _unitOfWork.TerapiaParticipanteViewRepository.GetsById(idTerapia);
        }
        public async Task DeleteTerapiaHorario(int idTerapia, int numero)
        {
            await _unitOfWork.TerapiaHorarioRepository.DeleteByIdsAndSave(idTerapia, numero);
        }
        public async Task DeleteTerapiaTerapeuta(int idTerapia, int numero)
        {
            await _unitOfWork.TerapiaTerapeutaRepository.DeleteByIdsAndSave(idTerapia, numero);
        }
        public async Task DeteleTerapiaParticipante(int idTerapia, int idParticipante)
        {
            await _unitOfWork.TerapiaParticipanteRepository.DeleteByIdsAndSave(idTerapia, idParticipante);
        }
        public Task<TerapiaParticipante> GetTerapiaParticipanteByIds(int idTerapia, int numero)
        {
            return _unitOfWork.TerapiaParticipanteRepository.GetByIds(idTerapia, numero);
        }
        public async Task<int> AddUpdateIndividualTherapyWithDetails(TerapiaDto terapiaDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            Terapia terapia = new Terapia()
            {
                IdLocal = terapiaDto.IdLocal,
                IdTarifa = terapiaDto.IdTarifa,
                FechaInicio = terapiaDto.FechaInicio,
                IdModalidad = terapiaDto.IdModalidad,
                SesionesMes = terapiaDto.SesionesMes,
                MinutosSesion = terapiaDto.MinutosSesion,
                IdSalon = terapiaDto.IdSalon,
                IdEstado = terapiaDto.IdEstado,
                Observaciones = terapiaDto.Observaciones == null ? "" : terapiaDto.Observaciones,
            };

            if (terapiaDto.Id == 0)
            {
                int idAtencion = await _unitOfWork.AtencionRepository.AddReturnId(new Atencion()
                {
                    IdPersona = 0,
                    IdTipoServicio = ETipoServicio.TerapiaIndivual,
                    Fecha = DateTime.Now,
                });

                terapia.UsuarioRegistro = usuario;

                id = await _unitOfWork.TerapiaRepository.AddReturnId(terapia);
                terapia.Id = id;

                await _unitOfWork.AtencionTerapiaRepository.Add(new AtencionTerapia()
                {
                    Id = idAtencion,
                    IdTwo = id,
                });
            }
            else
            {
                id = terapiaDto.Id;

                IEnumerable<AtencionTerapia> atencionTerapia = await _unitOfWork.AtencionTerapiaRepository.GetsByIdTwo(id);

                if (atencionTerapia.Count() == 0)
                {
                    int idAtencion = await _unitOfWork.AtencionRepository.AddReturnId(new Atencion()
                    {
                        IdPersona = 0,
                        IdTipoServicio = ETipoServicio.TerapiaIndivual,
                        Fecha = DateTime.Now,
                    });

                    await _unitOfWork.AtencionTerapiaRepository.AddAndSave(new AtencionTerapia()
                    {
                        Id = idAtencion,
                        IdTwo = id,
                    });
                }
                
                terapia.FechaRegistro = terapiaDto.FechaRegistro == null ? DateTime.Now : terapiaDto.FechaRegistro;
                terapia.UsuarioRegistro = terapiaDto.UsuarioRegistro == null ? usuario : terapiaDto.UsuarioRegistro;
                terapia.UsuarioModificacion = usuario;
                _unitOfWork.TerapiaRepository.UpdateAndSave(terapia);
            }

            foreach (var item in terapiaDto.TerapiaHorario)
            {
                if (item.Id == 0)
                {
                    if (item.DiaSemana > 0)
                    {
                        await _unitOfWork.TerapiaHorarioRepository.AddGenerateIdTwo(new TerapiaHorario()
                        {
                            Id = id,
                            DiaSemana = item.DiaSemana,
                            HoraInicio = TimeSpan.Parse(item.HoraInicio),
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaHorario terapiaHorario = await _unitOfWork.TerapiaHorarioRepository.GetByIds(id, item.Numero);

                    terapiaHorario.DiaSemana = item.DiaSemana;
                    terapiaHorario.HoraInicio = TimeSpan.Parse(item.HoraInicio);
                    terapiaHorario.UsuarioModificacion = usuario;

                    _unitOfWork.TerapiaHorarioRepository.UpdateAndSave(terapiaHorario);
                }
            }

            foreach (var item in terapiaDto.TerapiaTerapeuta)
            {
                if (item.Id == 0)
                {
                    if (item.IdTerapeuta> 0)
                    {
                        await _unitOfWork.TerapiaTerapeutaRepository.AddGenerateIdTwo(new TerapiaTerapeuta()
                        {
                            Id = id,
                            IdTerapeuta = item.IdTerapeuta,
                            IdTipoCargo = item.IdTipoCargo,
                            FechaInicio = item.FechaInicio,
                            FechaFin = item.FechaFin,
                            IdEstado = item.IdEstado,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaTerapeuta terapiaTerapeuta = await _unitOfWork.TerapiaTerapeutaRepository.GetByIds(id, item.Numero);

                    terapiaTerapeuta.IdTerapeuta = item.IdTerapeuta;
                    terapiaTerapeuta.IdTipoCargo = item.IdTipoCargo;
                    terapiaTerapeuta.FechaInicio = item.FechaInicio;
                    terapiaTerapeuta.FechaFin = item.FechaFin;
                    terapiaTerapeuta.IdEstado = item.IdEstado;
                    terapiaTerapeuta.UsuarioModificacion = usuario;

                    _unitOfWork.TerapiaTerapeutaRepository.UpdateAndSave(terapiaTerapeuta);
                }
            }

            foreach (var item in terapiaDto.TerapiaParticipante)
            {
                if (item.Id == 0)
                {
                    if (item.IdParticipante > 0)
                    {
                        await _unitOfWork.TerapiaParticipanteRepository.AddGenerateIdTwo(new TerapiaParticipante()
                        {
                            Id = id,
                            IdParticipante = item.IdParticipante,
                            IdEstado = item.IdEstado,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    var ee = await _unitOfWork.TerapiaParticipanteRepository.GetByIds(id, item.Numero);

                    TerapiaParticipante terapiaParticipante = await _unitOfWork.TerapiaParticipanteRepository.GetByIds(id, item.Numero);

                    terapiaParticipante.IdParticipante = item.IdParticipante;
                    terapiaParticipante.IdEstado = item.IdEstado;
                    terapiaParticipante.UsuarioModificacion = usuario;

                    _unitOfWork.TerapiaParticipanteRepository.UpdateAndSave(terapiaParticipante);
                }
            }

            return id;
        }
    }
}
