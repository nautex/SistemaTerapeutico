using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Services
{
    public class PuntuacionService : IPuntuacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PuntuacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddPuntuacionGrupo(PuntuacionGrupo PuntuacionGrupo)
        {
            return _unitOfWork.PuntuacionGrupoRepository.AddReturnId(PuntuacionGrupo);
        }

        public async Task DeletePuntuacionGrupo(int idPuntuacionGrupo)
        {
            await _unitOfWork.PuntuacionGrupoRepository.Delete(idPuntuacionGrupo);
            _unitOfWork.SaveChanges();
        }

        public async Task<PuntuacionGrupo> GetPuntuacionGrupo(int idPuntuacionGrupo)
        {
            return await _unitOfWork.PuntuacionGrupoRepository.GetById(idPuntuacionGrupo);
        }

        public IEnumerable<PuntuacionGrupo> GetsPuntuacionGrupo()
        {
            return _unitOfWork.PuntuacionGrupoRepository.GetAll();
        }
        public void UpdatePuntuacionGrupo(PuntuacionGrupo sesion)
        {
            _unitOfWork.PuntuacionGrupoRepository.Update(sesion);
            _unitOfWork.SaveChanges();
        }
    }
}
