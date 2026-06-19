using System.ComponentModel.DataAnnotations;

namespace MaintenanceSystem.Models
{
    public class Incident
    {
        public int Id { get; set; }
        public int? EquipmentId { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [MaxLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire.")]
        public string Description { get; set; } = string.Empty;
        public IncidentStatus Status { get; set; }
        public IncidentPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Technician? AssignedTo { get; set; }
      
    }
}