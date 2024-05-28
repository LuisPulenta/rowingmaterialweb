using Microsoft.EntityFrameworkCore;
using rowingmaterialweb.Shared.Entities;

namespace rowingmaterialweb.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<AppInstalacionesEquipo> AppInstalacionesEquipos { get; set; }
        public DbSet<AppInstalacionesEquiposDetalle> AppInstalacionesEquiposDetalles { get; set; }

    }

}
