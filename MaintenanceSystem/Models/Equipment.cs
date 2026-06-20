using System.ComponentModel.DataAnnotations;

namespace MaintenanceSystem.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [MaxLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La localisation est obligatoire.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "La catégorie est obligatoire.")]
        public string Category { get; set; } = string.Empty;

        public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}