using MaintenanceSystem.Data;
using MaintenanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MaintenanceSystem.Services
{
    public class IncidentService
    {
        private readonly AppDbContext _context;

        public IncidentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateIncidentAsync(Incident incident)
        {
            incident.CreatedAt = DateTime.Now;

            incident.Status = IncidentStatus.Open;

            await _context.Incidents.AddAsync(incident);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Incident>> GetAllIncidentsAsync()
        {
            return await _context.Incidents
                .Include(i => i.Equipment)
                .Include(i => i.AssignedTo)
                .OrderByDescending(i => i.CreatedAt)
                .ToListAsync();
        }
    }
}