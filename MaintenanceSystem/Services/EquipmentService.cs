using MaintenanceSystem.Data;
using MaintenanceSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceSystem.Services
{
    public class EquipmentService
    {
        private readonly AppDbContext _context;

        public EquipmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAllEquipmentsAsync()
        {
            return await _context.Equipments
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        public async Task CreateEquipmentAsync(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }
    }
}