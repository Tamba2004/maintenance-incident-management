using System;
using System.Threading.Tasks;
using MaintenanceSystem.Data;
using MaintenanceSystem.Models;

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
    }
}