using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<int> AddPersonaNaturalWithDetails(Persona persona)
        {
            int idPersona = 0;
            string usuario = "JSOTELO";

            //_unitOfWork.BeginTransaction();

            if (persona.Id == 0)
            {
                persona.UsuarioRegistro = usuario;

                idPersona = await _unitOfWork.PersonaRepository.AddReturnId(persona);
                persona.PersonaNatural.Id = idPersona;
                persona.IdEstado = EEstadoBasico.Activo;
                persona.PersonaNatural.UsuarioRegistro = usuario;

                await _unitOfWork.PersonaNaturalRepository.AddAndSave(persona.PersonaNatural);
            }
            else
            {
                idPersona = persona.Id;
                persona.FechaModificacion = DateTime.Now;
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
                    persona.PersonaNatural.FechaModificacion = DateTime.Now;
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
                        IdUbigeo = item.IdUbigeo,
                        Detalle = item.Detalle,
                        Referencia = item.Referencia,
                        FechaModificacion = DateTime.Now,
                        UsuarioModificacion = usuario,
                    });
                }

                if (item.IdDireccion > 0)
                {
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
                        personaDireccion.FechaModificacion = DateTime.Now;
                        personaDireccion.UsuarioModificacion = usuario;

                        _unitOfWork.PersonaDireccionRepository.UpdateAndSave(personaDireccion);
                    }
                }
            }

            foreach (var item in persona.PersonaDocumento)
            {
                if (item.Id == 0)
                {
                    if (!String.IsNullOrEmpty(item.NumeroDocumento))
                    {
                        item.Id = idPersona;
                        item.UsuarioRegistro = usuario;
                        await _unitOfWork.PersonaDocumentoRepository.AddGenerateIdTwo(item);
                    }
                }
                else
                {
                    PersonaDocumento personaDocumento = await _unitOfWork.PersonaDocumentoRepository.GetByIds(idPersona, item.IdTwo);

                    personaDocumento.IdTipoDocumento = item.IdTipoDocumento;
                    personaDocumento.NumeroDocumento = item.NumeroDocumento;
                    personaDocumento.FechaModificacion = DateTime.Now;
                    personaDocumento.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaDocumentoRepository.UpdateAndSave(personaDocumento);
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
                    PersonaContacto personaContacto = await _unitOfWork.PersonaContactoRepository.GetByIds(idPersona, item.IdTwo);

                    personaContacto.IdTipoContacto = item.IdTipoContacto;
                    personaContacto.Valor = item.Valor;
                    personaContacto.FechaModificacion = DateTime.Now;
                    personaContacto.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaContactoRepository.UpdateAndSave(personaContacto);
                }
            }

            foreach (var item in persona.PersonaVinculacion)
            {
                if (item.Id == 0)
                {
                    if (item.IdPersonaVinculo > 0)
                    {
                        item.Id = idPersona;
                        item.UsuarioRegistro = usuario;
                        await _unitOfWork.PersonaVinculacionRepository.AddGenerateIdTwo(item);
                    }
                }
                else
                {
                    PersonaVinculacion personaVinculacion = await _unitOfWork.PersonaVinculacionRepository.GetByIds(idPersona, item.IdTwo);
                    personaVinculacion.IdPersonaVinculo = item.IdPersonaVinculo;
                    personaVinculacion.IdTipoVinculo = item.IdTipoVinculo;
                    personaVinculacion.FechaModificacion = DateTime.Now;
                    personaVinculacion.UsuarioModificacion = usuario;
                    _unitOfWork.PersonaVinculacionRepository.UpdateAndSave(item);
                }
            }

            //_unitOfWork.SaveChanges();
            //_unitOfWork.CommitTransaction();

            return idPersona;
        }
        public async Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre)
        {
            return await _unitOfWork.PersonaRepository.GetPersonasByNombre(nombre);
        }
        public IEnumerable<PersonaResumenView> GetPersonasResumenView()
        {
            return _unitOfWork.PersonaResumenViewRepository.GetAll();
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
        public IEnumerable<PersonaResumenBasicoView> GetPersonasResumenBasicoViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres)
        {
            var list = _unitOfWork.PersonaResumenBasicoViewRepository.GetAll();

            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                list = list.Where(x => x.NumeroDocumento.ToLower().Contains(numeroDocumento.ToLower()));
            }

            if (!string.IsNullOrEmpty(nombres))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(nombres.ToLower()));
            }

            return list.ToList();
        }
        public IEnumerable<Lista> GetsListPersonByTypeAndName(int idType, string name)
        {
            var list = _unitOfWork.PersonaNaturalViewRepository.GetAll();

            if (idType >= 0)
            {
                list = list.Where(x => x.IdTipoPersona == idType);
            }

            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(name.ToLower()));
            }

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Nombres };

            return query;
        }
        public IEnumerable<PersonaResumenView> GetPersonasResumenViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres)
        {
            var list = _unitOfWork.PersonaResumenViewRepository.GetAll();

            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                list = list.Where(x => x.NumeroDocumento.Contains(numeroDocumento));
            }

            if (!string.IsNullOrEmpty(nombres))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(nombres.ToLower()));
            }

            return list.ToList();
        }
        public async Task DeletePersonaDireccion(int idPersona, int numero)
        {
            await _unitOfWork.PersonaDireccionRepository.DeleteByIdsAndSave(idPersona, numero);
        }
        public async Task DeletePersonaDocumento(int idPersona, int numero)
        {
            await _unitOfWork.PersonaDocumentoRepository.DeleteByIdsAndSave(idPersona, numero);
        }
        public async Task DeletePersonaContacto(int idPersona, int numero)
        {
            await _unitOfWork.PersonaContactoRepository.DeleteByIdsAndSave(idPersona, numero);
        }
        public async Task DeletePersonaVinculacion(int idPersona, int numero)
        {
            await _unitOfWork.PersonaVinculacionRepository.DeleteByIdsAndSave(idPersona, numero);
        }
    }
}
//123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100