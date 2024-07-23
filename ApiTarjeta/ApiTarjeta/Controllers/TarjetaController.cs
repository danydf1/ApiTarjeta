using ApiTarjeta.CasosDeUso;
using ApiTarjeta.Data;
using ApiTarjeta.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarjeta.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TarjetaController : Controller
    {
        private readonly TarjetaDBContext _tarjetaDBContext;
        private readonly IUpdateTarjetaUseCase _updateTarjetaUseCase;
        public TarjetaController(TarjetaDBContext tarjetaDBContext, IUpdateTarjetaUseCase updateTarjetaUseCase)
        {
            _tarjetaDBContext = tarjetaDBContext;
            _updateTarjetaUseCase = updateTarjetaUseCase;
        }
        //api/Tarjeta
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(List<Tarjeta>))]
        public async Task<IActionResult> GetTarjetas()
        {
            var result = _tarjetaDBContext.TarjetaDbContext.Select(t => t.toTarjeta()).ToList();

            return new OkObjectResult(result);
        }

        //api/Tarjeta/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(Tarjeta))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> GetTarjeta(int id)
        {
            TarjetaEntity result = await _tarjetaDBContext.Get(id);
            return new OkObjectResult(result.toTarjeta());
        }

        //api/Tarjeta/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(bool))]
        public async Task<IActionResult> DeleteTarjeta(int id)
        {
            var result = await _tarjetaDBContext.Delete(id);
            return new OkObjectResult(result);
        }

        //api/Tarjeta/{id}
        [HttpPost]
        [ProducesResponseType(statusCode: 201, Type = typeof(Tarjeta))]
        public async Task<IActionResult> InsertTarjeta(CreateTarjeta tarjeta)
        {
            TarjetaEntity result = await _tarjetaDBContext.Add(tarjeta);
            return new CreatedResult($"http://localhost:5201/api/Tarjeta/api/{result.Id}", null);
        }
        //api/Tarjeta/{id}
        [HttpPut]
        [ProducesResponseType(statusCode: 200, Type = typeof(Tarjeta))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> UpdateTarjeta(Tarjeta tarjeta)
        {
            Tarjeta? result = await _updateTarjetaUseCase.Execute(tarjeta);

            if (result == null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}
