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
            string usuario = "JSOTELO";

            //_unitOfWork.BeginTransaction();

            if (persona.Id == 0)
            {
                persona.UsuarioRegistro = usuario;

                idPersona = await _unitOfWork.PersonaRepository.AddReturnId(persona);
                persona.PersonaNatural.Id = idPersona;
                persona.PersonaNatural.UsuarioRegistro = usuario;

                await _unitOfWork.PersonaNaturalRepository.AddAndSave(persona.PersonaNatural);
            }
            else
            {
                idPersona = persona.Id;
                persona.UsuarioModificacion = usuario;
                _unitOfWork.PersonaRepository.UpdateAndSave(persona);

                PersonaNatural personaNatural = await _unitOfWork.PersonaNaturalRepository.GetById(idPersona);

                if (personaNatural == null)
                {
                    persona.PersonaNatural.Id = idPersona;
                    persona.PersonaNatural.UsuarioRegistro = usuario;

                    await _unitOfWork.PersonaNaturalRepository.AddAndSave(persona.PersonaNatural);
                }
                else
                {
                    persona.PersonaNatural.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaNaturalRepository.UpdateAndSave(persona.PersonaNatural);
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
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    _unitOfWork.DireccionRepository.UpdateAndSave(new Direccion()
                    {
                        Id = item.IdDireccion,
                        Detalle = item.Detalle,
                        Referencia = item.Referencia,
                        UsuarioModificacion = usuario,
                    });
                }

                if (item.Id == 0)
                {
                    await _unitOfWork.PersonaDireccionRepository.AddGenerateIdTwo(new PersonaDireccion()
                    {
                        Id = idPersona,
                        IdTipoDireccion = item.IdTipoDireccion,
                        IdDireccion = item.IdDireccion,
                        IdEstado = EEstadoBasico.Activo,
                        UsuarioRegistro = usuario,
                    });
                }
                else
                {
                    PersonaDireccion personaDireccion = await _unitOfWork.PersonaDireccionRepository.GetByIds(idPersona, item.Numero);

                    personaDireccion.IdTipoDireccion = item.IdTipoDireccion;
                    personaDireccion.IdDireccion = item.IdDireccion;
                    personaDireccion.UsuarioModificacion = usuario;

                    _unitOfWork.PersonaDireccionRepository.UpdateAndSave(personaDireccion);
                }
            }

            foreach (var item in persona.PersonaDocumento)
            {
                if (item.Id == 0)
                {
                    if (!String.IsNullOrEmpty(item.Numero))
                    {
                        item.Id = idPersona;
                        item.UsuarioRegistro = usuario;
                        await _unitOfWork.PersonaDocumentoRepository.AddAndSave(item);
                    }
                }
                else
                {
                    item.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaDocumentoRepository.UpdateAndSave(item);
                }
            }

            foreach (var item in persona.PersonaContacto)
            {
                if (item.Id == 0)
                {
                    if (!String.IsNullOrEmpty(item.Valor))
                    {
                        item.Id = idPersona;
                        item.UsuarioRegistro = usuario;
                        await _unitOfWork.PersonaContactoRepository.AddGenerateIdTwo(item);
                    }
                }
                else
                {
                    item.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaContactoRepository.UpdateAndSave(item);
                }
            }

            foreach (var item in persona.PersonaVinculacion)
            {
                if (item.Id == 0)
                {
                    if (item.IdTwo > 0)
                    {
                        item.Id = idPersona;
                        item.UsuarioRegistro = usuario;
                        await _unitOfWork.PersonaVinculacionRepository.AddReturnId(item);
                    }
                }
                else
                {
                    item.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaVinculacionRepository.UpdateAndSave(item);
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