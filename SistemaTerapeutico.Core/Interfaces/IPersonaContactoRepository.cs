using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaContactoRepository : IBaseRepository<PersonaContacto>
    {
        int GetNewNumeroByIdPersona(int idPersona);
    }
}
