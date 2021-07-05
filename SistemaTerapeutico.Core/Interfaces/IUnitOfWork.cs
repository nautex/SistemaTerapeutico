using System;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IPersonaVinculacionRepository PersonaVinculacionRepository { get; }
        IPersonaContactoRepository PersonaContactoRepository { get; }
        IPersonaDireccionRepository PersonaDireccionDireccion { get; }
        IPersonaNaturalRepository PersonaNaturalRepository { get; }
        IPersonaDocumentoRepository PersonaDocumentoRepository { get; }
        ICatalogoRepository CatalogoRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
