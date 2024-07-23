using ApiTarjeta.Data;
using ApiTarjeta.Dtos;

namespace ApiTarjeta.CasosDeUso
{
    public interface IUpdateTarjetaUseCase
    {
        Task<Tarjeta?> Execute(Tarjeta tarjeta);
    }

    public class UpdateTarjetaUseCase : IUpdateTarjetaUseCase
    {
        private readonly TarjetaDBContext _tarjetaDBContext;

        public UpdateTarjetaUseCase(TarjetaDBContext tarjetaDBContext)
        {
            _tarjetaDBContext = tarjetaDBContext;
        }

        public async Task<Tarjeta?> Execute(Tarjeta tarjeta)
        {
            var Entity = await _tarjetaDBContext.Get(tarjeta.Id);

            if (Entity == null)
                return null;

            Entity.Titular = tarjeta.Titular;
            Entity.NumeroTarjeta = tarjeta.NumeroTarjeta;
            Entity.FechaExpiracion = tarjeta.FechaExpiracion;
            Entity.cvv = tarjeta.cvv;

            await _tarjetaDBContext.UpdateTarjeta(Entity);

            return Entity.toTarjeta();
        }
    }
}
