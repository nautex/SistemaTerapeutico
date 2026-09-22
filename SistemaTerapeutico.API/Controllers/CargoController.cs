using SistemaTerapeutico.API.Response;
using AutoMapper;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class CargoController : Controller
    {
        private readonly CargoService _cargoService;

        public CargoController(CargoService fichaService, IMapper mapper)
        {
            _cargoService = fichaService;
        }
        [HttpGet("GetCargoViewById")]
        public async Task<IActionResult> GetCargoViewById(int id)
        {
            var response = await _cargoService.GetCargoViewById(id);
            return Ok(response);
        }
        [HttpPost("PostCargo")]
        public async Task<IActionResult> PostCargo([FromBody] CargoView entityView)
        {
            int id = await _cargoService.PostCargo(entityView);
            var Response = new ApiResponse<int>(id);

            return Ok(Response);
        }
        [HttpGet("GetsCargoViewSearchBasic")]
        public async Task<IActionResult> GetsCargoViewSearchBasic(string descripcion, int idEstado)
        {
            var response = await _cargoService.GetsCargoViewSearchBasic(descripcion, idEstado);
            return Ok(response);
        }
        [HttpPost("AnnulCargo")]
        public async Task<IActionResult> AnnulCargo(int idCargo)
        {
            await _cargoService.AnnulCargo(idCargo);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
        [HttpPost("ActiveCargo")]
        public async Task<IActionResult> ActiveCargo(int idCargo)
        {
            await _cargoService.AnnulCargo(idCargo);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }
    }
}
