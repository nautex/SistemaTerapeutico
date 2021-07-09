using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class ParticipanteService : IParticipanteService
    {
        public async Task AddParticipante(Participante participante)
        {
            Participante participante = new Participante("JSOTELO");
            participante.Id = participanteDto.Id;
            participante.IdTerapeuta = participanteDto.IdTerapeuta;
            participante.LugarCasoAccidente = participanteDto.LugarCasoAccidente;
            participante.DetalleHermanos = participanteDto.DetalleHermanos;
            participante.TieneDiagnostico = participanteDto.TieneDiagnostico;
            participante.UsuarioRegistro = "JSOTELO";

        }
    }
}
