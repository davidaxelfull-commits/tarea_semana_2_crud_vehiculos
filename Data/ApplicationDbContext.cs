using Clase_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clase_2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<VehiculosModel> Vehiculos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<CentroRevision> CentroRevisiones { get; set; }
    }
}
