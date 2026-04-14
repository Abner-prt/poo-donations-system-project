namespace donations_system_app.Entities;

public class DonationEntity
{
    public int Id { get; set; }
    public int DonorId { get; set; }
    public string Type { get; set; } = string.Empty; // Dinero o Articulo
    public string Description { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string Status { get; set; } = "Available"; // Disponible o Entregado
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Relacion con el donante
    public DonorEntity? Donor { get; set; }
}
