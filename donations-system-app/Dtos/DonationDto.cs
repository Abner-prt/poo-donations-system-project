namespace donations_system_app.Dtos;

public class DonationDto
{
    public int DonorId { get; set; }
    public string Type { get; set; } // 'Money'/'Item'
    public string Description { get; set; }
    public double Quantity { get; set; }
}
