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
        public async Task<int> AddPersona(Persona persona)
        {
            if (!persona.EsEmpresa && (string.IsNullOrEmpty(persona.Nombres) || persona.Nombres.Length < 3))
            {
                throw new BusinessException("El nombre de la pesona debe tener mas de 3 caracteres.");
            }

            if (persona.EsEmpresa && (string.IsNullOrEmpty(persona.RazonSocial) || persona.RazonSocial.Length < 3))
            {
                throw new BusinessException("La razon social de la empresa debe tener mas de 3 caracteres.");
            }

            await _unitOfWork.PersonaRepository.Add(persona);

            return persona.Id;
        }
        public void UpdatePersona(Persona persona)
        {
            _unitOfWork.PersonaRepository.Update(persona);
        }
        public Task DeletePersona(int idPersona)
        {
            return _unitOfWork.PersonaRepository.Delete(idPersona);
        }
        public Task AddChildWithParents(PersonaNaturalDatosCompletosDto child, PersonaNaturalDatosCompletosDto mother, PersonaNaturalDatosCompletosDto pather)
        {
            Task<int> idChild = AddPersonaNaturalDatosCompletos(child);
            Task<int> idMother = AddPersonaNaturalDatosCompletos(mother);
            Task<int> idPather = AddPersonaNaturalDatosCompletos(child);
        }

        public async Task<int> AddPersonaNaturalDatosCompletos(PersonaNaturalDatosCompletosDto personaDto)
        {
            _unitOfWork.BeginTransaction();

            int idPersona = await AddPersona(new Persona(personaDto.UsuarioRegistro)
            {
                Nombres = personaDto.PrimerApellido + " " + personaDto.SegundoApellido + " " + personaDto.PrimerNombre + " " + personaDto.SegundoNombre,
                FechaIngreso = personaDto.FechaIngreso,
                IdPaisOrigen = personaDto.IdPaisOrigen
            });

            await _unitOfWork.PersonaNaturalRepository.Add(new PersonaNatural(personaDto.UsuarioRegistro)
            {
                Id = idPersona,
                PrimerNombre = personaDto.PrimerNombre,
                SegundoNombre = personaDto.SegundoNombre,
                PrimerApellido = personaDto.PrimerApellido,
                SegundoApelldio = personaDto.SegundoApellido,
                FechaNacimiento = personaDto.FechaNacimiento,
                IdSexo = personaDto.IdSexo
            });

            if (!String.IsNullOrEmpty(personaDto.DetalleDireccion))
            {
                await AddDireccionPersona(new PersonaDireccionDto
                {
                    IdPersona = persona.Id,
                    IdTipoDireccion = ETipoDireccion.Domicilio,
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

                _unitOfWork.SaveChanges();
            }

            if (!string.IsNullOrEmpty(personaDto.Celular))
            {
                PersonaContacto personaContactoCelular = new PersonaContacto("JSOTELO")
                {
                    Id = persona.Id,
                    IdTipoContacto = ETipoContacto.CelularMovistar,
                    Valor = personaDto.Celular
                };

                await _unitOfWork.PersonaContactoRepository.Add(personaContactoCelular);

                _unitOfWork.SaveChanges();
            }

            if (!string.IsNullOrEmpty(personaDto.Correo))
            {
                PersonaContacto personaContactoCorreo = new PersonaContacto("JSOTELO")
                {
                    Id = persona.Id,
                    IdTipoContacto = ETipoContacto.Correo,
                    Valor = personaDto.Correo
                };

                await _unitOfWork.PersonaContactoRepository.Add(personaContactoCorreo);

                _unitOfWork.SaveChanges();
            }

            return persona.Id;
        }

        public async Task AddDireccionPersona(PersonaDireccionDto personaDireccionDto, string usuarioRegistro)
        {
            int idDireccion = personaDireccionDto.IdDireccion;

            if (idDireccion == 0)
            {
                Direccion direccion = new Direccion(usuarioRegistro)
                {
                    IdUbigeo = personaDireccionDto.IdUbigeo,
                    Detalle = personaDireccionDto.Detalle,
                    Referencia = personaDireccionDto.Referencia
                };

                await _unitOfWork.DireccionRepository.Add(direccion);

                _unitOfWork.SaveChanges();

                idDireccion = direccion.Id;
            }

            PersonaDireccion personaDireccion = new PersonaDireccion(usuarioRegistro)
            {
                Id = personaDireccionDto.IdPersona,
                IdDireccion = idDireccion,
                IdTipoDireccion = personaDireccionDto.IdTipoDireccion
            };

            await _unitOfWork.PersonaDireccionRepository.Add(personaDireccion);

            _unitOfWork.SaveChanges();
        }
    }
}
