using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
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
        public async Task<IEnumerable<ParticipantePersonaAutorizadaView>> GetsParticipantePersonaAutorizadaViewById(int idParticipante)
        {
            return await _unitOfWork.ParticipantePersonaAutorizadaViewRepository.GetsById(idParticipante);
        }
        public async Task<int> AddUpdateParticipanteWithDetails(Participante participante)
        {
            int id = 0;
            string usuario = "JSOTELO";

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
    }
}
