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

        public async Task<Incident?> GetIncidentByIdAsync(int id)
        {
            return await _context.Incidents
                .Include(i => i.Equipment)
                .Include(i => i.AssignedTo)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AssignTechnicianAsync(int incidentId, int technicianId)
        {
            var incident = await _context.Incidents.FindAsync(incidentId);
            if (incident == null) return;

            incident.AssignedToId = technicianId;
            incident.Status = IncidentStatus.Assigned;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int incidentId, IncidentStatus newStatus)
        {
            var incident = await _context.Incidents.FindAsync(incidentId);
            if (incident == null) return;

            incident.Status = newStatus;

            if (newStatus == IncidentStatus.Resolved)
                incident.ResolvedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<int> CountByStatusAsync(IncidentStatus status)
        {
            return await _context.Incidents
                .CountAsync(i => i.Status == status);
        }

        public async Task<int> CountByPriorityAsync(IncidentPriority priority)
        {
            return await _context.Incidents
                .CountAsync(i => i.Priority == priority);
        }

        public async Task<int> CountResolvedTodayAsync()
        {
            var today = DateTime.Today;
            return await _context.Incidents
                .CountAsync(i => i.ResolvedAt != null && i.ResolvedAt.Value.Date == today);
        }

        public async Task<List<Incident>> GetRecentIncidentsAsync(int count = 5)
        {
            return await _context.Incidents
                .Include(i => i.Equipment)
                .OrderByDescending(i => i.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
    }
}