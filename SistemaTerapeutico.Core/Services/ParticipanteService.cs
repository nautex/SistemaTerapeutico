using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddParticipante(Participante participante)
        {
            await _unitOfWork.ParticipanteRepository.Add(participante);
            _unitOfWork.SaveChanges();
        }
        public Task<Participante> GetParticipanteById(int idParticipante)
        {
            return _unitOfWork.ParticipanteRepository.GetById(idParticipante);
        }
        public IEnumerable<ParticipanteResumenView> GetsParticipantesResumenView()
        {
            return _unitOfWork.ParticipanteResumenViewRepository.GetAll();
        }
        public async Task<ParticipanteView> GetParticipanteViewById(int idParticipante)
        {
            return await _unitOfWork.ParticipanteViewRepository.GetById(idParticipante);
        }
        public IEnumerable<ParticipanteResumenView> GetsParticipantesResumenViewByMemberOrRelative(string member, string relative)
        {
            var list = _unitOfWork.ParticipanteResumenViewRepository.GetAll();

            if (!string.IsNullOrEmpty(member))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(member.ToLower()));
            }

            if (!string.IsNullOrEmpty(relative))
            {
                list = list.Where(x => (x.Madre.ToLower().Contains(relative.ToLower())
                    || x.Padre.ToLower().Contains(relative.ToLower())
                    || x.PersonasAutorizadas.ToLower().Contains(relative.ToLower())));
            }

            return list.ToList();
        }
        public async Task<IEnumerable<ParticipanteAlergiaView>> GetsParticipanteAlergiaViewById(int idParticipante)
        {
            return await _unitOfWork.ParticipanteAlergiaViewRepository.GetsById(idParticipante);
        }

        public async Task<IEnumerable<ParticipanteNivelLenguajeView>> GetsParticipanteNivelLenguajeViewById(int idParticipante)
        {
            return await _unitOfWork.ParticipanteNivelLenguajeViewRepository.GetsById(idParticipante);
        }
        public async Task<IEnumerable<ParticipantePersonaAutorizadaView>> GetsParticipantePersonaAutorizadaViewById(int idParticipante)
        {
            return await _unitOfWork.ParticipantePersonaAutorizadaViewRepository.GetsById(idParticipante);
        }
        public async Task<int> AddUpdateParticipanteWithDetails(Participante participante)
        {
            int id = 0;
            string usuario = "JSOTELO";

            _unitOfWork.BeginTransaction();

            try
            {
                if (participante.Id == 0)
                {
                    participante.UsuarioRegistro = usuario;

                    id = await _unitOfWork.ParticipanteRepository.AddReturnId(participante);
                    participante.Id = id;
                }
                else
                {
                    id = participante.Id;
                    participante.FechaModificacion = DateTime.Now;
                    participante.UsuarioModificacion = usuario;
                    _unitOfWork.ParticipanteRepository.UpdateAndSave(participante);
                }

                foreach (var item in participante.ParticipanteAlergia)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdTipoAlergia > 0)
                        {
                            await _unitOfWork.ParticipanteAlergiaRepository.AddGenerateIdTwo(new ParticipanteAlergia()
                            {
                                Id = id,
                                IdTipoAlergia = item.IdTipoAlergia,
                                Detalle = item.Detalle,
                                UsuarioRegistro = usuario,
                            });
                        }
                    }
                    else
                    {
                        ParticipanteAlergia participanteAlergia = await _unitOfWork.ParticipanteAlergiaRepository.GetByIds(id, item.Numero);

                        participanteAlergia.IdTipoAlergia = item.IdTipoAlergia;
                        participanteAlergia.Detalle = item.Detalle;
                        participanteAlergia.FechaModificacion = DateTime.Now;
                        participanteAlergia.UsuarioModificacion = usuario;

                        _unitOfWork.ParticipanteAlergiaRepository.UpdateAndSave(participanteAlergia);
                    }
                }

                foreach (var item in participante.ParticipantePersonaAutorizada)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdPersona > 0)
                        {
                            await _unitOfWork.ParticipantePersonaAutorizadaRepository.AddGenerateIdTwo(new ParticipantePersonaAutorizada()
                            {
                                Id = id,
                                IdPersona = item.IdPersona,
                                UsuarioRegistro = usuario,
                            });
                        }
                    }
                    else
                    {
                        ParticipantePersonaAutorizada participantePersonaAutorizada = await _unitOfWork.ParticipantePersonaAutorizadaRepository.GetByIds(id, item.Numero);

                        participantePersonaAutorizada.IdPersona = item.IdPersona;
                        participantePersonaAutorizada.FechaModificacion = DateTime.Now;
                        participantePersonaAutorizada.UsuarioModificacion = usuario;

                        _unitOfWork.ParticipantePersonaAutorizadaRepository.UpdateAndSave(participantePersonaAutorizada);
                    }
                }

                foreach (var item in participante.ParticipanteNivelLenguaje)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdNivelLenguaje > 0)
                        {
                            await _unitOfWork.ParticipanteNivelLenguajeRepository.AddGenerateIdTwo(new ParticipanteNivelLenguaje()
                            {
                                Id = id,
                                IdNivelLenguaje = item.IdNivelLenguaje,
                                UsuarioRegistro = usuario,
                            });
                        }
                    }
                    else
                    {
                        ParticipanteNivelLenguaje participanteNivelLenguaje = await _unitOfWork.ParticipanteNivelLenguajeRepository.GetByIds(id, item.Numero);

                        participanteNivelLenguaje.IdNivelLenguaje = item.IdNivelLenguaje;
                        participanteNivelLenguaje.FechaModificacion = DateTime.Now;
                        participanteNivelLenguaje.UsuarioModificacion = usuario;

                        _unitOfWork.ParticipanteNivelLenguajeRepository.UpdateAndSave(participanteNivelLenguaje);
                    }
                }

                foreach (var item in participante.PersonaVinculacion)
                {
                    if (item.Id == 0 | item.Numero == 0)
                    {
                        if (item.IdPersonaVinculo > 0)
                        {
                            item.Id = participante.IdPersona;
                            item.UsuarioRegistro = usuario;
                            item.FechaRegistro = DateTime.Now;
                            await _unitOfWork.PersonaVinculacionRepository.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaVinculacion personaVinculacion = await _unitOfWork.PersonaVinculacionRepository.GetByIds(participante.IdPersona, item.Numero);
                        personaVinculacion.IdPersonaVinculo = item.IdPersonaVinculo;
                        personaVinculacion.IdTipoVinculo = item.IdTipoVinculo;
                        personaVinculacion.FechaModificacion = DateTime.Now;
                        personaVinculacion.UsuarioModificacion = usuario;
                        _unitOfWork.PersonaVinculacionRepository.UpdateAndSave(item);
                    }
                }

                _unitOfWork.SaveChanges();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }

            return id;
        }
        public async Task DeleteParticipanteAlergia(int idPersona, int numero)
        {
            await _unitOfWork.ParticipanteAlergiaRepository.DeleteByIdsAndSave(idPersona, numero);
        }
        public async Task DeleteParticipantePersonaAutorizada(int idPersona, int numero)
        {
            await _unitOfWork.ParticipantePersonaAutorizadaRepository.DeleteByIdsAndSave(idPersona, numero);
        }

        public async Task DeleteParticipanteNivelLenguaje(int idPersona, int numero)
        {
            await _unitOfWork.ParticipanteNivelLenguajeRepository.DeleteByIdsAndSave(idPersona, numero);
        }
    }
}
