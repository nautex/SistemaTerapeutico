using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SISDETContext context) : base(context)
        {

        }

        public async Task DeleteByCodigo(string codigo)
        {
            var entity = await GetUsuarioByCodigo(codigo);
            _entities.Remove(entity);
        }

        public async Task<Usuario> GetUsuarioByCodigo(string codigo)
        {
            return await _entities.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioByCodigoYClave(string codigo, string clave)
        {
            return await _entities.Where(x => x.Codigo == codigo && x.Clave == clave).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona)
        {
            return await _entities.Where(x => x.Id == idPersona).ToListAsync();
        }
    }
}
