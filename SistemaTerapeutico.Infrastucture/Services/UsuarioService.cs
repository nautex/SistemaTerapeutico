using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class UsuarioService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public UsuarioService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddUsuario(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            _context.SaveChanges();
        }

        public void DeleteUsuario(string codigo)
        {
            var entity = GetUsuarioByCodigo(codigo);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Usuario GetByUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioByCodigo(string codigo)
        {
            return await _context.Usuario.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByCodigoYClave(string codigo, string clave)
        {
            return await _context.Usuario.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.GetAll<Usuario>();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona)
        {
            return await _context.Usuario.Where(x => x.Id == idPersona).ToListAsync();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}
