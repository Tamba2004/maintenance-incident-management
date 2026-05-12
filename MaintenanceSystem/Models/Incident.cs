namespace MaintenanceSystem.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public int? EquipmentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentStatus Status { get; set; }
        public IncidentPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Technician? AssignedTo { get; set; }
      
    }
}