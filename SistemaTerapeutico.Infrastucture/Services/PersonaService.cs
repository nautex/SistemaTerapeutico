using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Extensions;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PersonaService(
            SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.GetAll<Persona>();
        }
        public Task<Persona> GetPersonaById(int idPersona)
        {
            return _context.GetById<Persona>(idPersona);
        }
        public async Task<int> AddPersona(Persona persona)
        {
            if ((string.IsNullOrEmpty(persona.Nombres) || persona.Nombres.Length < 3))
            {
                throw new BusinessException("El nombre de la persona debe tener mas de 3 caracteres.");
            }

            await _context.AddReturnId(persona);

            return persona.Id;
        }
        public void UpdatePersona(Persona persona)
        {
            _context.Update(persona);
            _context.SaveChanges();
        }
        public async Task DeletePersona(int idPersona)
        {
            await _context.Delete<Persona>(idPersona);
            _context.SaveChanges();
        }
        public async Task<int> AddPersonaNaturalWithDetails(Persona persona)
        {
            int idPersona = 0;
            string usuario = "JSOTELO";

            _context.BeginTransaction();
                
            try
            {
                if (persona.Id == 0)
                {
                    persona.FechaRegistro = DateTime.Now;
                    persona.UsuarioRegistro = usuario;

                    idPersona = await _context.AddReturnId(persona);
                }
                else
                {
                    idPersona = persona.Id;
                    persona.FechaRegistro = persona.FechaRegistro ?? DateTime.Now;
                    persona.UsuarioRegistro = persona.UsuarioRegistro ?? usuario;
                    persona.FechaModificacion = DateTime.Now;
                    persona.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(persona);
                }

                PersonaNatural personaNatural = await _context.GetById<PersonaNatural>(idPersona);

                if (personaNatural == null)
                {
                    persona.PersonaNatural.Id = idPersona;
                    persona.PersonaNatural.SegundoNombre = persona.PersonaNatural.SegundoNombre ?? "";
                    persona.PersonaNatural.IdEstado = EEstadoBasico.Activo;
                    persona.PersonaNatural.UsuarioRegistro = usuario;
                    persona.PersonaNatural.FechaRegistro = DateTime.Now;

                    await _context.AddAndSave(persona.PersonaNatural);
                }
                else
                {
                    persona.PersonaNatural.FechaModificacion = DateTime.Now;
                    persona.PersonaNatural.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(persona.PersonaNatural);
                }

                foreach (var item in persona.PersonaDireccion)
                {
                    if (item.IdDireccion == 0)
                    {
                        if (!string.IsNullOrEmpty(item.Detalle))
                        {
                            item.IdDireccion = await _context.AddReturnId(new Direccion()
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
                        _context.UpdateAndSave(new Direccion()
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
                            await _context.AddGenerateIdTwo(new PersonaDireccion()
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
                            PersonaDireccion personaDireccion = await _context.GetByIds<PersonaDireccion>(idPersona, item.Numero);

                            personaDireccion.IdTipoDireccion = item.IdTipoDireccion;
                            personaDireccion.IdDireccion = item.IdDireccion;
                            personaDireccion.FechaModificacion = DateTime.Now;
                            personaDireccion.UsuarioModificacion = usuario;

                            _context.UpdateAndSave(personaDireccion);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaDocumento personaDocumento = await _context.GetByIds<PersonaDocumento>(idPersona, item.Numero);

                        personaDocumento.IdTipoDocumento = item.IdTipoDocumento;
                        personaDocumento.NumeroDocumento = item.NumeroDocumento;
                        personaDocumento.FechaModificacion = DateTime.Now;
                        personaDocumento.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(personaDocumento);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaContacto personaContacto = await _context.GetByIds<PersonaContacto>(idPersona, item.Numero);

                        personaContacto.IdTipoContacto = item.IdTipoContacto;
                        personaContacto.Valor = item.Valor;
                        personaContacto.FechaModificacion = DateTime.Now;
                        personaContacto.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(personaContacto);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaVinculacion personaVinculacion = await _context.GetByIds<PersonaVinculacion>(idPersona, item.Numero);
                        personaVinculacion.IdPersonaVinculo = item.IdPersonaVinculo;
                        personaVinculacion.IdTipoVinculo = item.IdTipoVinculo;
                        personaVinculacion.FechaModificacion = DateTime.Now;
                        personaVinculacion.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(personaVinculacion);
                    }
                }

                //foreach (var item in persona.PersonaAntecedente)
                //{
                //    if (item.Id == 0)
                //    {
                //        if (item.IdTipoAntecedente > 0)
                //        {
                //            item.Id = idPersona;
                //            item.FechaRegistro = DateTime.Now;
                //            item.UsuarioRegistro = usuario;
                //            await _context.AddGenerateIdTwo(item);
                //        }
                //    }
                //    else
                //    {
                //        PersonaAntecedente entity = await _context.GetByIds<PersonaAntecedente>(idPersona, item.IdTwo);
                //        entity.IdTipoAntecedente = item.IdTipoAntecedente;
                //        entity.FechaModificacion = DateTime.Now;
                //        entity.UsuarioModificacion = usuario;
                //        _context.UpdateAndSave(entity);
                //    }
                //}

                _context.SaveChanges();
                _context.CommitTransaction();
            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                throw;
            }

            return idPersona;
        }
        public async Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre)
        {
            return await _context.Persona.Where(x => x.Nombres.Contains(nombre)).ToListAsync();
        }
        public IEnumerable<PersonaResumenView> GetPersonasResumenView()
        {
            return _context.GetAll<PersonaResumenView>().ToList().OrderByDescending(x => x.FechaRegistro).Take(50);
        }
        public Task<PersonaNatural> GetPersonaNaturalById(int idPersona)
        {
            return _context.GetById<PersonaNatural>(idPersona);
        }
        public async Task AddPersonaNatural(PersonaNatural personaNatural)
        {
            await _context.AddAsync(personaNatural);
            _context.SaveChanges();
        }
        public void UpdatePersonaNatural(PersonaNatural personaNatural)
        {
            _context.Update(personaNatural);
            _context.SaveChanges();
        }
        public async Task DeletePersonaNatural(int idPersona)
        {
            await _context.Delete<PersonaNatural>(idPersona);
            _context.SaveChanges();
        }
        public async Task<PersonaNaturalView> GetPersonaNaturalViewById(int idPersona)
        {
            return await _context.GetById<PersonaNaturalView>(idPersona);
        }
        public async Task<PersonaJuridicaView> GetPersonaJuridicaViewById(int idPersona)
        {
            return await _context.GetById<PersonaJuridicaView>(idPersona);
        }
        public async Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosViewByIdPersona(int idPersona)
        {
            return await _context.PersonaDocumentoView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
        public async Task<IEnumerable<PersonaRepresentanteView>> GetsPersonaRepresentanteViewById(int idPersona)
        {
            return await _context.PersonaRepresentanteView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }

        public async Task<IEnumerable<PersonaContactoView>> GetPersonasContactosViewByIdPersona(int idPersona)
        {
            return await _context.PersonaContactoView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }

        public async Task<IEnumerable<PersonaDireccionView>> GetPersonasDireccionesViewByIdPersona(int idPersona)
        {
            return await _context.PersonaDireccionView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
        public async Task<IEnumerable<PersonaVinculacionView>> GetPersonasVinculacionesViewByIdPersona(int idPersona)
        {
            return await _context.PersonaVinculacionView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
        public async Task<IEnumerable<PersonaAntecedenteView>> GetPersonasAntecedenteViewByIdPersona(int idPersona)
        {
            return await _context.PersonaAntecedenteView.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
        public IEnumerable<PersonaResumenBasicoView> GetPersonasResumenBasicoViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres, string empresa)
        {
            var list = _context.GetAll<PersonaResumenBasicoView>();

            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                list = list.Where(x => x.NumeroDocumento.ToLower().Contains(numeroDocumento.ToLower()));
            }

            if (!string.IsNullOrEmpty(nombres))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(nombres.ToLower()));
            }

            if (!string.IsNullOrEmpty(empresa))
            {
                list = list.Where(x => x.Empresa.ToLower().Contains(empresa.ToLower()));
            }

            return list.ToList().OrderByDescending(x => x.FechaRegistro).Take(50);
        }
        public IEnumerable<Lista> GetsListNaturalPersonByTypeAndName(int idType, string name)
        {
            var list = _context.GetAll<PersonaResumenView>();

            list = list.Where(x => x.EsEmpresa == false);

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
        public IEnumerable<Lista> GetsListLegalPersonByTypeAndName(int idType, string name)
        {
            var list = _context.GetAll<PersonaResumenView>();

            list = list.Where(x => x.EsEmpresa == true);

            if (idType >= 0)
            {
                list = list.Where(x => x.IdTipoEmpresa == idType);
            }

            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(name.ToLower()));
            }

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Nombres };

            return query;
        }
        public IEnumerable<PersonaResumenView> GetPersonasResumenViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres, string empresa)
        {
            var list = _context.GetAll<PersonaResumenView>();

            if (!string.IsNullOrWhiteSpace(numeroDocumento))
            {
                list = list.Where(x => x.NumeroDocumento != null && x.NumeroDocumento.Contains(numeroDocumento));
            }

            if (!string.IsNullOrWhiteSpace(nombres))
            {
                list = list.Where(x => x.Nombres.ToLower().Contains(nombres.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(empresa))
            {
                list = list.Where(x => x.Empresa.ToLower().Contains(empresa.ToLower()));
            }

            return list.ToList().OrderByDescending(x => x.FechaRegistro).Take(50);
        }
        public async Task DeletePersonaDireccion(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<PersonaDireccion>(idPersona, numero);
        }
        public async Task DeletePersonaDocumento(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<PersonaDocumento>(idPersona, numero);
        }
        public async Task DeletePersonaRepresentante(int id)
        {
            await _context.DeleteAndSave<PersonaRepresentante>(id);
        }
        public async Task DeletePersonaContacto(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<PersonaContacto>(idPersona, numero);
        }
        public async Task DeletePersonaVinculacion(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<PersonaVinculacion>(idPersona, numero);
        }
        public async Task DeletePersonaAntecedente(int idPersona, int numero)
        {
            await _context.DeleteByIdsAndSave<PersonaAntecedente>(idPersona, numero);
        }
        public async Task AddPersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            IEnumerable<PersonaVinculacion> list = await _context.PersonaVinculacion.Where(
                x => (x.Id == personaVinculacion.Id && x.IdPersonaVinculo == personaVinculacion.IdPersonaVinculo) 
                || (x.IdPersonaVinculo == personaVinculacion.Id && x.Id == personaVinculacion.IdPersonaVinculo)).ToListAsync();

            if (list.ToList().Count == 0)
            {
                await _context.AddGenerateIdTwo(personaVinculacion);
                _context.SaveChanges();
            }
        }
        public PersonaResumenBasicoView GetPersonaResumenBasicoViewByTipoDocumentoAndNumeroDocumento(int idTipoDocumento, string numeroDocumento)
        {
            var list = _context.GetAll<PersonaResumenBasicoView>();

            if (idTipoDocumento >= 0)
            {
                list = list.Where(x => x.IdTipoDocumento == idTipoDocumento);
            }
            if (!string.IsNullOrEmpty(numeroDocumento))
            {
                list = list.Where(x => x.NumeroDocumento.ToLower().Contains(numeroDocumento.ToLower()));
            }

            return list.ToList().First();
        }
        public async Task<IEnumerable<PersonaDocumento>> GetsPersonaDocumentoByTipoYNumero(int idTipoDocumento, string numeroDocumento)
        {
            return await _context.PersonaDocumento.Where(x => x.IdTipoDocumento == idTipoDocumento && x.NumeroDocumento == numeroDocumento).ToListAsync();
        }


        public async Task<int> AddPersonaJuridicaWithDetails(PersonaJuridicaWDDto personaDto)
        {
            int idPersona = 0;
            string usuario = "JSOTELO";

            _context.BeginTransaction();

            try
            {
                Persona persona = _mapper.Map<Persona>(personaDto);

                if (persona.Id == 0)
                {
                    persona.EsEmpresa = true;
                    persona.FechaRegistro = DateTime.Now;
                    persona.UsuarioRegistro = usuario;

                    idPersona = await _context.AddReturnId(persona);
                }
                else
                {
                    idPersona = persona.Id;
                    persona.EsEmpresa = true;
                    persona.FechaRegistro = persona.FechaRegistro ?? DateTime.Now;
                    persona.UsuarioRegistro = persona.UsuarioRegistro ?? usuario;
                    persona.FechaModificacion = DateTime.Now;
                    persona.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(persona);
                }

                PersonaJuridica personaJuridica = await _context.GetById<PersonaJuridica>(idPersona);

                if (personaJuridica == null)
                {
                    personaJuridica.Id = idPersona;
                    personaJuridica.RazonSocial = personaDto.RazonSocial ?? "";
                    personaJuridica.IdTipo = personaDto.IdTipo;
                    personaJuridica.UsuarioRegistro = usuario;
                    personaJuridica.FechaRegistro = DateTime.Now;

                    await _context.AddAndSave(personaJuridica);
                }
                else
                {
                    personaJuridica.RazonSocial = personaDto.RazonSocial ?? "";
                    personaJuridica.IdTipo = personaDto.IdTipo;
                    personaJuridica.FechaModificacion = DateTime.Now;
                    personaJuridica.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(personaJuridica);
                }

                foreach (var item in persona.PersonaDireccion)
                {
                    if (item.IdDireccion == 0)
                    {
                        if (!string.IsNullOrEmpty(item.Detalle))
                        {
                            item.IdDireccion = await _context.AddReturnId(new Direccion()
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
                        _context.UpdateAndSave(new Direccion()
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
                            await _context.AddGenerateIdTwo(new PersonaDireccion()
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
                            PersonaDireccion personaDireccion = await _context.GetByIds<PersonaDireccion>(idPersona, item.Numero);

                            personaDireccion.IdTipoDireccion = item.IdTipoDireccion;
                            personaDireccion.IdDireccion = item.IdDireccion;
                            personaDireccion.FechaModificacion = DateTime.Now;
                            personaDireccion.UsuarioModificacion = usuario;

                            _context.UpdateAndSave(personaDireccion);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaDocumento personaDocumento = await _context.GetByIds<PersonaDocumento>(idPersona, item.Numero);

                        personaDocumento.IdTipoDocumento = item.IdTipoDocumento;
                        personaDocumento.NumeroDocumento = item.NumeroDocumento;
                        personaDocumento.FechaModificacion = DateTime.Now;
                        personaDocumento.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(personaDocumento);
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
                            await _context.AddGenerateIdTwo(item);
                        }
                    }
                    else
                    {
                        PersonaContacto personaContacto = await _context.GetByIds<PersonaContacto>(idPersona, item.Numero);

                        personaContacto.IdTipoContacto = item.IdTipoContacto;
                        personaContacto.Valor = item.Valor;
                        personaContacto.FechaModificacion = DateTime.Now;
                        personaContacto.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(personaContacto);
                    }
                }

                foreach (var item in personaDto.PersonaRepresentante)
                {
                    if (item.Id == 0)
                    {
                        if (item.IdRepresentante > 0)
                        {
                            PersonaRepresentante entity = _mapper.Map<PersonaRepresentante>(item);

                            entity.IdPersona = personaDto.Id;
                            entity.UsuarioRegistro = usuario;
                            entity.Id = await _context.AddReturnId(entity);
                        }
                    }
                    else
                    {
                        PersonaRepresentante entity = await _context.GetById<PersonaRepresentante>(item.Id);
                        entity.IdRepresentante = item.IdRepresentante;
                        entity.IdCargo = item.IdCargo;
                        entity.IdEstadoLaboral = item.IdEstadoLaboral;
                        entity.FechaModificacion = DateTime.Now;
                        entity.UsuarioModificacion = usuario;
                        _context.UpdateAndSave(entity);
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

            return idPersona;
        }
        public IEnumerable<Lista> GetsListPersonaRepresentanteByIdPersona(int idPersona)
        {
            var list = _context.GetAll<PersonaRepresentanteView>();

            list = list.Where(x => x.IdPersona == idPersona);

            var query = from f in list.ToList() select new Lista { Id = f.IdRepresentante, Descripcion = f.Representante };

            return query;
        }
    }
}
//123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100
