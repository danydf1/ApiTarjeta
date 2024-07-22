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
        public TarjetaController(TarjetaDBContext tarjetaDBContext)
        {
            _tarjetaDBContext = tarjetaDBContext;
        }
        //api/Tarjeta
        [HttpGet]
        [ProducesResponseType(statusCode: 200, Type = typeof(Tarjeta))]
        public async Task<IActionResult> GetTarjetas()
        {
            throw new NotImplementedException();
        }

        //api/Tarjeta/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(Tarjeta))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> GetTarjeta(int id)
        {
            throw new NotImplementedException();
        }

        //api/Tarjeta/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(bool))]
        public async Task<IActionResult> DeleteTarjeta(int id)
        {
            throw new NotImplementedException();
        }

        //api/Tarjeta/{id}
        [HttpPost]
        [ProducesResponseType(statusCode: 201, Type = typeof(Tarjeta))]
        public async Task<IActionResult> InsertTarjeta(CreateTarjeta tarjeta)
        {
            TarjetaEnitity result = await _tarjetaDBContext.Add(tarjeta);
            return new CreatedResult($"http://localhost:5201/api/Tarjeta/api/{result.Id}", null);
        }
        //api/Tarjeta/{id}
        [HttpPut]
        [ProducesResponseType(statusCode: 200, Type = typeof(Tarjeta))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> UpdateTarjeta(int id)
        {
            throw new NotImplementedException();
        }
    }
}
