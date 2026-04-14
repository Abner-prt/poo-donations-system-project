namespace donations_system_app.Entities;

public class DonorEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Persona o Empresa
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    // Lista de donaciones
    public ICollection<DonationEntity> Donations { get; set; } = new List<DonationEntity>();
}
