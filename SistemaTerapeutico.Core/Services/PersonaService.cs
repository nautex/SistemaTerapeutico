using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Persona>> GetPersonas()
        {
            return _unitOfWork.PersonaRepository.GetAll();
        }
        public Task<Persona> GetPersonaById(int idPersona)
        {
            return _unitOfWork.PersonaRepository.GetById(idPersona);
        }
        public Task AddPersona(Persona persona)
        {
            return _unitOfWork.PersonaRepository.Add(persona);
        }
        public void UpdatePersona(Persona persona)
        {
            _unitOfWork.PersonaRepository.Update(persona);
        }
        public Task DeletePersona(int idPersona)
        {
            return _unitOfWork.PersonaRepository.Delete(idPersona);
        }

        //public Task AddChildWithParents(PersonaNaturalDatosCompletosDto child, PersonaNaturalDatosCompletosDto mother, PersonaNaturalDatosCompletosDto pather)
        //{
        //    Task<int> idChild = AddPersonaNaturalDatosCompletos(child);
        //    Task<int> idMother = AddPersonaNaturalDatosCompletos(mother);
        //    Task<int> idPather = AddPersonaNaturalDatosCompletos(child);
        //}

        public async Task<int> AddPersonaNaturalDatosCompletos(PersonaNaturalDatosCompletosDto personaDto)
        {
            if (string.IsNullOrEmpty(personaDto.PrimerNombre) || string.IsNullOrEmpty(personaDto.PrimerApellido))
            {
                throw new BusinessException("Por lo menos se debe ingresar el primer nombre y apellido de la persona.");
            }

            Persona persona = new Persona("JSOTELO")
            {
                Nombres = personaDto.PrimerApellido + " " + personaDto.SegundoApellido + " " + personaDto.PrimerNombre + " " + personaDto.SegundoNombre,
                FechaIngreso = personaDto.FechaIngreso,
                IdPaisOrigen = personaDto.IdPaisOrigen
            };

            await _unitOfWork.PersonaRepository.Add(persona);

            PersonaNatural personaNatural = new PersonaNatural("JSOTELO")
            {
                Id = persona.Id,
                PrimerNombre = personaDto.PrimerNombre,
                SegundoNombre = personaDto.SegundoNombre,
                PrimerApellido = personaDto.PrimerApellido,
                SegundoApelldio = personaDto.SegundoApellido,
                FechaNacimiento = personaDto.FechaNacimiento,
                IdSexo = (eSexo)personaDto.IdSexo
            };

            if (!String.IsNullOrEmpty(personaDto.DetalleDireccion))
            {
                await AddDireccionPersona(new PersonaDireccionDto
                {
                    IdPersona = persona.Id,
                    IdTipoDireccion = eTipoDireccion.Domicilio,
                    IdUbigeo = personaDto.IdUbigeoDireccion,
                    Detalle = personaDto.DetalleDireccion,
                    Referencia = ""
                }, "JSOTELO");
            }

            if (!string.IsNullOrEmpty(personaDto.NumeroDocumento))
            {
                PersonaDocumento personaDocumento = new PersonaDocumento("JSOTELO")
                {
                    Id = persona.Id,
                    IdTipoDocumento = personaDto.IdTipoDocumento,
                    Numero = personaDto.NumeroDocumento
                };

                await _unitOfWork.PersonaDocumentoRepository.Add(personaDocumento);
            }

            if (!string.IsNullOrEmpty(personaDto.Celular))
            {
                PersonaContacto personaContactoCelular = new PersonaContacto("JSOTELO")
                {
                    Id = persona.Id,
                    IdTipoContacto = eTipoContacto.CelularMovistar,
                    Valor = personaDto.Celular
                };

                await _unitOfWork.PersonaContactoRepository.Add(personaContactoCelular);
            }

            if (!string.IsNullOrEmpty(personaDto.Correo))
            {
                PersonaContacto personaContactoCorreo = new PersonaContacto("JSOTELO")
                {
                    Id = persona.Id,
                    IdTipoContacto = eTipoContacto.Correo,
                    Valor = personaDto.Correo
                };

                await _unitOfWork.PersonaContactoRepository.Add(personaContactoCorreo);
            }

            _unitOfWork.SaveChanges();

            return persona.Id;
        }

        public async Task AddDireccionPersona(PersonaDireccionDto personaDireccionDto, string usuarioRegistro)
        {
            int idDireccion = personaDireccionDto.IdDireccion;

            if (idDireccion == 0)
            {
                Direccion direccion = new Direccion(usuarioRegistro)
                {
                    IdUbigeo = (eUbigeo)personaDireccionDto.IdUbigeo,
                    Detalle = personaDireccionDto.Detalle,
                    Referencia = personaDireccionDto.Referencia
                };

                await _unitOfWork.DireccionRepository.Add(direccion);

                idDireccion = direccion.Id;
            }

            PersonaDireccion personaDireccion = new PersonaDireccion(usuarioRegistro)
            {
                Id = personaDireccionDto.IdPersona,
                IdDireccion = idDireccion,
                IdTipoDireccion = (eTipoDireccion)personaDireccionDto.IdTipoDireccion,
                Numero = _unitOfWork.PersonaDireccionRepository.GetNewNumeroByIdPersona(personaDireccionDto.IdPersona)
            };

            await _unitOfWork.PersonaDireccionRepository.Add(personaDireccion);

            _unitOfWork.SaveChanges();
        }
    }
}
