using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Persona> GetPersonas()
        {
            return _unitOfWork.PersonaRepository.GetAll();
        }
        public Task<Persona> GetPersonaById(int idPersona)
        {
            return _unitOfWork.PersonaRepository.GetById(idPersona);
        }
        public async Task<int> AddPersona(Persona persona)
        {
            if ((string.IsNullOrEmpty(persona.Nombres) || persona.Nombres.Length < 3))
            {
                throw new BusinessException("El nombre de la persona debe tener mas de 3 caracteres.");
            }

            await _unitOfWork.PersonaRepository.AddReturnId(persona);

            return persona.Id;
        }
        public void UpdatePersona(Persona persona)
        {
            _unitOfWork.PersonaRepository.Update(persona);
            _unitOfWork.SaveChanges();
        }
        public async Task DeletePersona(int idPersona)
        {
            await _unitOfWork.PersonaRepository.Delete(idPersona);
            _unitOfWork.SaveChanges();
        }
        //public async Task<int> AddChildWithParents(PersonaNaturalDatosCompletosDto child, PersonaNaturalDatosCompletosDto mother, PersonaNaturalDatosCompletosDto dad)
        //{
        //    int idChild = await AddPersonaNaturalDatosCompletos(child);

        //    //mother.IdDireccion = child.MamaMismaDireccion ? child.IdDireccion : 0;
        //    //dad.IdDireccion = child.PapaMismaDireccion ? child.IdDireccion : 0;

        //    //int idMother = await AddPersonaNaturalDatosCompletos(mother);
        //    //int idDad = await AddPersonaNaturalDatosCompletos(child);

        //    //await _unitOfWork.PersonaVinculacionRepository.Add(new PersonaVinculacion(child.UsuarioRegistro)
        //    //{
        //    //    Id = idChild,
        //    //    IdPersonaVinculo = idMother,
        //    //    IdTipoVinculo = ETipoVinculo.Madre
        //    //});

        //    //await _unitOfWork.PersonaVinculacionRepository.Add(new PersonaVinculacion(child.UsuarioRegistro)
        //    //{
        //    //    Id = idChild,
        //    //    IdPersonaVinculo = idDad,
        //    //    IdTipoVinculo = ETipoVinculo.Padre
        //    //});

        //    //_unitOfWork.SaveChanges();

        //    //return idChild;
        //    return 0;
        //}

        public async Task<PersonaResponseDto> AddPersonaNaturalWithDetails(Persona persona)
        {
            int idPersona = 0;
            int? idDireccion = null;

            //_unitOfWork.BeginTransaction();

            if (persona.Id == 0)
            {
                idPersona = await _unitOfWork.PersonaRepository.AddReturnId(persona);
                await _unitOfWork.PersonaNaturalRepository.AddReturnId(persona.PersonaNatural);
            }
            else
            {
                idPersona = persona.Id;
                _unitOfWork.PersonaRepository.Update(persona);
                PersonaNatural personaNatural = await _unitOfWork.PersonaNaturalRepository.GetById(persona.Id);

                if (personaNatural == null)
                {
                    await _unitOfWork.PersonaNaturalRepository.Add(persona.PersonaNatural);
                }
                else
                {
                    _unitOfWork.PersonaNaturalRepository.Update(persona.PersonaNatural);
                }
            }

            foreach (var item in persona.PersonaDireccion)
            {
                if (item.IdDireccion == 0)
                {
                    if (!string.IsNullOrEmpty(item.Detalle))
                    {
                        item.IdDireccion = await _unitOfWork.DireccionRepository.AddReturnId(new Direccion()
                        {
                            IdUbigeo = item.IdUbigeo,
                            Detalle = item.Detalle,
                            Referencia = item.Referencia,
                            IdEstado = EEstadoBasico.Activo,
                            UsuarioRegistro = "JSOTELO",
                        });
                    }
                }

                if (item.Id == 0)
                {
                    await _unitOfWork.PersonaDireccionRepository.AddGenerateIdTwo(new PersonaDireccion()
                    {
                        Id = persona.Id,
                        IdTipoDireccion = item.IdTipoDireccion,
                        IdDireccion = item.IdDireccion,
                        IdEstado = EEstadoBasico.Activo,
                    });
                }
                else
                {
                    PersonaDireccion personaDireccion = await _unitOfWork.PersonaDireccionRepository.GetByIds(persona.Id, item.Numero);

                    personaDireccion.IdTipoDireccion = item.IdTipoDireccion;
                    personaDireccion.IdDireccion = item.IdDireccion;
                    personaDireccion.FechaModificacion = DateTime.Now;
                    personaDireccion.UsuarioModificacion = "JSOTELO";

                    _unitOfWork.PersonaDireccionRepository.Update(personaDireccion);
                }
            }

            for (int i = 0; i < persona.PersonaDocumento.Count(); i++)
            {
                if (persona.PersonaDocumento[i].Id == 0)
                {
                    persona.PersonaDocumento[i].Id = persona.Id;
                    await _unitOfWork.PersonaDocumentoRepository.AddReturnId(persona.PersonaDocumento[i]);
                }
                else
                {
                    _unitOfWork.PersonaDocumentoRepository.Update(persona.PersonaDocumento[i]);
                }
            }

            for (int i = 0; i < persona.PersonaContacto.Count(); i++)
            {
                if (persona.PersonaContacto[i].Id == 0)
                {
                    persona.PersonaContacto[i].Id = persona.Id;
                    await _unitOfWork.PersonaContactoRepository.AddGenerateIdTwo(persona.PersonaContacto[i]);
                }
                else
                {
                    _unitOfWork.PersonaContactoRepository.Update(persona.PersonaContacto[i]);
                }
            }

            for (int i = 0; i < persona.PersonaVinculacion.Count(); i++)
            {
                if (persona.PersonaVinculacion[i].Id == 0)
                {
                    persona.PersonaVinculacion[i].Id = persona.Id;
                    await _unitOfWork.PersonaVinculacionRepository.AddReturnId(persona.PersonaVinculacion[i]);
                }
                else
                {
                    _unitOfWork.PersonaVinculacionRepository.Update(persona.PersonaVinculacion[i]);
                }
            }

            //PersonaNatural personaNatural = await _unitOfWork.PersonaNaturalRepository.GetById(idPersona);

            //if (personaNatural.Id == 0)
            //{
            //    await _unitOfWork.PersonaNaturalRepository.Add(new PersonaNatural()
            //    {
            //        Id = idPersona,
            //        PrimerNombre = persona.PersonaNatural.PrimerNombre,
            //        SegundoNombre = persona.PersonaNatural.SegundoNombre,
            //        PrimerApellido = persona.PersonaNatural.PrimerApellido,
            //        SegundoApellido = persona.PersonaNatural.SegundoApellido,
            //        FechaNacimiento = persona.PersonaNatural.FechaNacimiento,
            //        IdSexo = persona.PersonaNatural.IdSexo,
            //    });
            //}
            //else
            //{

            //}


            //if (personaDto.IdDireccion > 0)
            //{
            //    idDireccion = personaDto.IdDireccion;
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(personaDto.DetalleDireccion))
            //    {
            //        idDireccion = await _unitOfWork.DireccionRepository.AddReturnId(new Direccion()
            //        {
            //            Id = idPersona,
            //            IdUbigeo = personaDto.IdUbigeoDireccion,
            //            Detalle = personaDto.DetalleDireccion
            //        });
            //    }
            //}

            //if (idDireccion != null)
            //{
            //    await _unitOfWork.PersonaDireccionRepository.AddGenerateIdTwo(new PersonaDireccion()
            //    {
            //        Id = idPersona,
            //        IdTipoDireccion = ETipoDireccion.Domicilio,
            //        IdDireccion = idDireccion
            //    });
            //}

            //if (!string.IsNullOrEmpty(personaDto.NumeroDocumento))
            //{
            //    await _unitOfWork.PersonaDocumentoRepository.Add(new PersonaDocumento()
            //    {
            //        Id = idPersona,
            //        IdTwo = personaDto.IdTipoDocumento,
            //        Numero = personaDto.NumeroDocumento
            //    });
            //}

            //if (!string.IsNullOrEmpty(personaDto.Celular))
            //{
            //    await _unitOfWork.PersonaContactoRepository.AddGenerateIdTwo(new PersonaContacto()
            //    {
            //        Id = idPersona,
            //        IdTipoContacto = ETipoContacto.CelularMovistar,
            //        Valor = personaDto.Celular
            //    });
            //}

            //if (!string.IsNullOrEmpty(personaDto.Correo))
            //{
            //    await _unitOfWork.PersonaContactoRepository.AddGenerateIdTwo(new PersonaContacto()
            //    {
            //        Id = idPersona,
            //        IdTipoContacto = ETipoContacto.Correo,
            //        Valor = personaDto.Correo
            //    });
            //}

            //_unitOfWork.SaveChanges();
            //_unitOfWork.CommitTransaction();

            return new PersonaResponseDto { IdPersona = idPersona, IdDireccion = idDireccion };
        }
        public async Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre)
        {
            return await _unitOfWork.PersonaRepository.GetPersonasByNombre(nombre);
        }
        public IEnumerable<PersonaResumenView> GetPersonasResumenView()
        {
            return _unitOfWork.PersonaViewRepository.GetAll();
        }
        public Task<PersonaNatural> GetPersonaNaturalById(int idPersona)
        {
            return _unitOfWork.PersonaNaturalRepository.GetById(idPersona);
        }
        public async Task AddPersonaNatural(PersonaNatural personaNatural)
        {
            await _unitOfWork.PersonaNaturalRepository.Add(personaNatural);
            _unitOfWork.SaveChanges();
        }
        public void UpdatePersonaNatural(PersonaNatural personaNatural)
        {
            _unitOfWork.PersonaNaturalRepository.Update(personaNatural);
            _unitOfWork.SaveChanges();
        }
        public async Task DeletePersonaNatural(int idPersona)
        {
            await _unitOfWork.PersonaNaturalRepository.Delete(idPersona);
            _unitOfWork.SaveChanges();
        }
        public async Task<PersonaNaturalView> GetPersonaNaturalViewById(int idPersona)
        {
            return await _unitOfWork.PersonaNaturalViewRepository.GetById(idPersona);
        }
        public async Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosViewByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaDocumentoViewRepository.GetPersonasDocumentosByIdPersona(idPersona);
        }

        public async Task<IEnumerable<PersonaContactoView>> GetPersonasContactosViewByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaContactoViewRepository.GetPersonasContactosViewByIdPersona(idPersona);
        }

        public async Task<IEnumerable<PersonaDireccionView>> GetPersonasDireccionesViewByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaDireccionViewRepository.GetPersonasDireccionesViewByIdPersona(idPersona);
        }
        public async Task<IEnumerable<PersonaVinculacionView>> GetPersonasVinculacionesViewByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaVinculacionViewRepository.GetPersonasVinculacionesViewByIdPersona(idPersona);
        }
        public IEnumerable<PersonaDocumentoView> GetPersonasDocumentosViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres)
        {
            var list = _unitOfWork.PersonaDocumentoViewRepository.GetAll();

            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                list = list.Where(x => x.Numero.ToLower().Contains(numeroDocumento.ToLower()));
            }

            if (!string.IsNullOrEmpty(nombres))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(nombres.ToLower()));
            }

            return list.ToList();
        }
    }
}
//123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100