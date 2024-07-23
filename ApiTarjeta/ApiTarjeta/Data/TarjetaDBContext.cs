using ApiTarjeta.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ApiTarjeta.Data
{
    public class TarjetaDBContext : DbContext
    {
        public DbSet<TarjetaEntity> TarjetaDbContext { get; set; }
        public TarjetaDBContext(DbContextOptions<TarjetaDBContext> options) : base(options)
        {
        }

        public async Task<TarjetaEntity?> Get(int id)
        {
            return await TarjetaDbContext.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            TarjetaEntity entity = await Get(id);
            TarjetaDbContext.Remove(entity);
            SaveChanges();
            return true;
        }

        public async Task<TarjetaEntity> Add(CreateTarjeta tarjeta)
        {
            TarjetaEntity tarjetaEnitity = new TarjetaEntity()
            {
                Id = null,
                Titular = tarjeta.Titular,
                NumeroTarjeta = tarjeta.NumeroTarjeta,
                FechaExpiracion = tarjeta.FechaExpiracion,
                cvv = tarjeta.cvv

            };
            EntityEntry<TarjetaEntity> Response = await TarjetaDbContext.AddAsync(tarjetaEnitity);
            await SaveChangesAsync();

            return await Get(Response.Entity.Id ?? throw new Exception("No trae null"));
        }

        public async Task<bool> UpdateTarjeta(TarjetaEntity tarjeta)
        {
            TarjetaDbContext.Update(tarjeta);
            await SaveChangesAsync();

            return true;
        }
    }


    public class TarjetaEntity
    {
        public int? Id { get; set; }
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaExpiracion { get; set; }
        public string cvv { get; set; }

        public Tarjeta toTarjeta()
        {
            return new Tarjeta()
            {
                Id = Id ?? throw new Exception("No trae null"),
                Titular = Titular,
                NumeroTarjeta = NumeroTarjeta,
                FechaExpiracion = FechaExpiracion,
                cvv = cvv
            };
        }
    }
}
