using MaintenanceSystem.Data;
using MaintenanceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceSystem.Services
{
    public class TechnicianService
    {
        private readonly AppDbContext _context;

        public TechnicianService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Technician>> GetAllTechniciansAsync()
        {
            return await _context.Technicians
                .OrderBy(t => t.FullName)
                .ToListAsync();
        }

        public async Task CreateTechnicianAsync(Technician technician)
        {
            await _context.Technicians.AddAsync(technician);
            await _context.SaveChangesAsync();
        }
    }
}