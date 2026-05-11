namespace MaintenanceSystem.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}