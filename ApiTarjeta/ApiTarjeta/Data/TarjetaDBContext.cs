using ApiTarjeta.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ApiTarjeta.Data
{
    public class TarjetaDBContext : DbContext
    {
        public DbSet<TarjetaEnitity> TarjetaDbContext { get; set; }
        public TarjetaDBContext(DbContextOptions<TarjetaDBContext> options) : base(options)
        {
        }
        public async Task<TarjetaEnitity> Get(int id)
        {
            return await TarjetaDbContext.FirstAsync(x => x.Id == id);
        }
        public async Task<TarjetaEnitity> Add(CreateTarjeta tarjeta)
        {
            TarjetaEnitity tarjetaEnitity = new TarjetaEnitity()
            {
                Id = null,
                Titular = tarjeta.Titular,
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                FechaExpiracion = tarjeta.FechaExpiracion,
                cvv = tarjeta.cvv

            };
            EntityEntry<TarjetaEnitity> Response = await TarjetaDbContext.AddAsync(tarjetaEnitity);
            await SaveChangesAsync();

            return await Get(Response.Entity.Id ?? throw new Exception("No se pudo guardar"));
        }
    }


    public class TarjetaEnitity
    {
        public int? Id { get; set; }
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string cvv { get; set; }
    }
}
