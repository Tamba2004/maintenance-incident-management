using Microsoft.EntityFrameworkCore;
using MaintenanceSystem.Models;

namespace MaintenanceSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}