using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class ParticipanteService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public ParticipanteService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddParticipante(Participante participante)
        {
            await _context.AddAsync(participante);
            _context.SaveChanges();
        }
        public Task<Participante> GetParticipanteById(int idParticipante)
        {
            return _context.GetById<Participante>(idParticipante);
        }
        public IEnumerable<ParticipanteResumenView> GetsParticipantesResumenView()
        {
            return _context.GetAll<ParticipanteResumenView>();
        }
        public async Task<ParticipanteView> GetParticipanteViewById(int idParticipante)
        {
            return await _context.GetById<ParticipanteView>(idParticipante);
        }
        public IEnumerable<ParticipanteResumenView> GetsParticipantesResumenViewByMemberOrRelative(string member, string relative)
        {
            var list = _context.GetAll<ParticipanteResumenView>();

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
            var list = await _context.GetAllAsync<ParticipanteAlergiaView>();

            list = list.Where(x => x.Id == idParticipante);

            return list.ToList();
        }

        public async Task<IEnumerable<ParticipanteNivelLenguajeView>> GetsParticipanteNivelLenguajeViewById(int idParticipante)
        {
            var list = await _context.GetAllAsync<ParticipanteNivelLenguajeView>();

            list = list.Where(x => x.Id == idParticipante);

            return list.ToList();
        }
        public async Task<IEnumerable<ParticipantePersonaAutorizadaView>> GetsParticipantePersonaAutorizadaViewById(int idParticipante)
        {
            var list = await _context.GetAllAsync<ParticipantePersonaAutorizadaView>();

            list = list.Where(x => x.Id == idParticipante);

            return list.ToList();
        }
        public async Task<int> AddUpdateParticipanteWithDetails(Participante participante)
        {
            int id = 0;
            string usuario = "JSOTELO";

            _context.BeginTransaction();

            try
            {
                if (participante.Id == 0)
                {
                    participante.UsuarioRegistro = usuario;

                    id = await _context.AddReturnId(participante);
                    participante.Id = id;
                }
                else
                {
                    id = participante.Id;
                    participante.FechaModificacion = DateTime.Now;
                    participante.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(participante);
                }

                foreach (var item in participante.ParticipanteAlergia)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdTipoAlergia > 0)
                        {
                            await _context.AddGenerateIdTwo(new ParticipanteAlergia()
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
                        ParticipanteAlergia participanteAlergia = await _context.GetByIds<ParticipanteAlergia>(id, item.Numero);

                        participanteAlergia.IdTipoAlergia = item.IdTipoAlergia;
                        participanteAlergia.Detalle = item.Detalle;
                        participanteAlergia.FechaModificacion = DateTime.Now;
                        participanteAlergia.UsuarioModificacion = usuario;

                        _context.UpdateAndSave(participanteAlergia);
                    }
                }

                foreach (var item in participante.ParticipantePersonaAutorizada)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdPersona > 0)
                        {
                            await _context.AddGenerateIdTwo(new ParticipantePersonaAutorizada()
                            {
                                Id = id,
                                IdPersona = item.IdPersona,
                                UsuarioRegistro = usuario,
                            });
                        }
                    }
                    else
                    {
                        ParticipantePersonaAutorizada participantePersonaAutorizada = await _context.GetByIds<ParticipantePersonaAutorizada>(id, item.Numero);

                        participantePersonaAutorizada.IdPersona = item.IdPersona;
                        participantePersonaAutorizada.FechaModificacion = DateTime.Now;
                        participantePersonaAutorizada.UsuarioModificacion = usuario;

                        _context.UpdateAndSave(participantePersonaAutorizada);
                    }
                }

                foreach (var item in participante.ParticipanteNivelLenguaje)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdNivelLenguaje > 0)
                        {
                            await _context.AddGenerateIdTwo(new ParticipanteNivelLenguaje()
                            {
                                Id = id,
                                IdNivelLenguaje = item.IdNivelLenguaje,
                                UsuarioRegistro = usuario,
                            });
                        }
                    }
                    else
                    {
                        ParticipanteNivelLenguaje participanteNivelLenguaje = await _context.GetByIds<ParticipanteNivelLenguaje>(id, item.Numero);

                        participanteNivelLenguaje.IdNivelLenguaje = item.IdNivelLenguaje;
                        participanteNivelLenguaje.FechaModificacion = DateTime.Now;
                        participanteNivelLenguaje.UsuarioModificacion = usuario;

                        _context.UpdateAndSave(participanteNivelLenguaje);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaVinculacion personaVinculacion = await _context.GetByIds<PersonaVinculacion>(participante.IdPersona, item.Numero);
                        personaVinculacion.IdPersonaVinculo = item.IdPersonaVinculo;
                        personaVinculacion.IdTipoVinculo = item.IdTipoVinculo;
                        personaVinculacion.FechaModificacion = DateTime.Now;
                        personaVinculacion.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(item);
                    }
                }

                _context.SaveChanges();
                _context.CommitTransaction();
            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                throw;
            }

            return id;
        }
        public async Task DeleteParticipanteAlergia(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<ParticipanteAlergia>(idPersona, numero);
        }
        public async Task DeleteParticipantePersonaAutorizada(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<ParticipantePersonaAutorizada>(idPersona, numero);
        }

        public async Task DeleteParticipanteNivelLenguaje(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<ParticipanteNivelLenguaje>(idPersona, numero);
        }
    }
}
