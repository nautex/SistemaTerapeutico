using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class Repository : IRepository
    {
        private SISDETContext _context;

        public Repository(SISDETContext context)
        {
            _context = context;
        }

        private DbSet<T> Setear<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Listar<T>() where T : class
        {
            return Setear<T>();
        }

        public T Obtener<T>(object id) where T : class
        {
            return Setear<T>().Find(id);
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }

        public void Agregar<T>(T entidad) where T : class
        {
            Setear<T>().Add(entidad);
        }
    }
}