namespace donations_system_app.Dtos;

public class DonationDto
{
    public int DonorId { get; set; }
    public string Type { get; set; } = string.Empty; // Dinero o Articulo
    public string Description { get; set; } = string.Empty;
    public double Quantity { get; set; }
}
