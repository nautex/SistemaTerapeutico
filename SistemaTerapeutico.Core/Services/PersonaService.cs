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
        public async Task<int> AddChildWithParents(PersonaNaturalDatosCompletosDto child, PersonaNaturalDatosCompletosDto mother, PersonaNaturalDatosCompletosDto dad)
        {
            int idChild = await AddPersonaNaturalDatosCompletos(child);

            mother.IdDireccion = child.MamaMismaDireccion ? child.IdDireccion : 0;
            dad.IdDireccion = child.PapaMismaDireccion ? child.IdDireccion : 0;

            int idMother = await AddPersonaNaturalDatosCompletos(mother);
            int idDad = await AddPersonaNaturalDatosCompletos(child);

            await _unitOfWork.PersonaVinculacionRepository.Add(new PersonaVinculacion(child.UsuarioRegistro)
            {
                Id = idChild,
                IdPersonaVinculo = idMother,
                IdTipoVinculo = ETipoVinculo.Madre
            });

            await _unitOfWork.PersonaVinculacionRepository.Add(new PersonaVinculacion(child.UsuarioRegistro)
            {
                Id = idChild,
                IdPersonaVinculo = idDad,
                IdTipoVinculo = ETipoVinculo.Padre
            });

            _unitOfWork.SaveChanges();

            return idChild;
        }

        public async Task<int> AddPersonaNaturalDatosCompletos(PersonaNaturalDatosCompletosDto personaDto)
        {
            int idPersona;
            int? idDireccion = null;

            _unitOfWork.BeginTransaction();

            idPersona = await _unitOfWork.PersonaRepository.AddReturnId(new Persona(personaDto.UsuarioRegistro)
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

            if (personaDto.IdDireccion > 0)
            {
                idDireccion = personaDto.IdDireccion;
            }
            else
            {
                if (!string.IsNullOrEmpty(personaDto.DetalleDireccion))
                {
                    idDireccion = await _unitOfWork.DireccionRepository.AddReturnId(new Direccion(personaDto.UsuarioRegistro)
                    {
                        Id = idPersona,
                        IdUbigeo = personaDto.IdUbigeoDireccion,
                        Detalle = personaDto.DetalleDireccion
                    });
                }
            }

            if (idDireccion != null)
            {
                await _unitOfWork.PersonaDireccionRepository.Add(new PersonaDireccion(personaDto.UsuarioRegistro)
                {
                    Id = idPersona,
                    IdTipoDireccion = ETipoDireccion.Domicilio,
                    IdDireccion = idDireccion
                });
            }

            if (!string.IsNullOrEmpty(personaDto.NumeroDocumento))
            {
                await _unitOfWork.PersonaDocumentoRepository.Add(new PersonaDocumento(personaDto.UsuarioRegistro)
                {
                    Id = idPersona,
                    IdTipoDocumento = personaDto.IdTipoDocumento,
                    Numero = personaDto.NumeroDocumento
                });
            }

            if (!string.IsNullOrEmpty(personaDto.Celular))
            {
                await _unitOfWork.PersonaContactoRepository.Add(new PersonaContacto(personaDto.UsuarioRegistro)
                {
                    Id = idPersona,
                    IdTipoContacto = ETipoContacto.CelularMovistar,
                    Valor = personaDto.Celular
                });

                _unitOfWork.SaveChanges();
            }

            if (!string.IsNullOrEmpty(personaDto.Correo))
            {
                await _unitOfWork.PersonaContactoRepository.Add(new PersonaContacto(personaDto.UsuarioRegistro)
                {
                    Id = idPersona,
                    IdTipoContacto = ETipoContacto.Correo,
                    Valor = personaDto.Correo
                });
            }

            _unitOfWork.SaveChanges();
            _unitOfWork.CommitTransaction();

            return idPersona;
        }
    }
}
