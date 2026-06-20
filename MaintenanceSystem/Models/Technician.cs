using System.ComponentModel.DataAnnotations;

namespace MaintenanceSystem.Models
{
    public class Technician
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " Le Nom complet est obligatoire  est obligatoire.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = " Le EMail est obligatoire.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le departememt est obligatoire.")]
        public string Department { get; set; } = string.Empty;
    }
}