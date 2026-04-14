namespace donations_system_app.Entities;

public class DonationEntity
{
    public int Id { get; set; }
    public int DonorId { get; set; }
    public string Type { get; set; } // 'Money'--'Item'
    public string Description { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string Status { get; set; } = "Available"; // 'Available'--'Delivered'
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public DonorEntity Donor { get; set; }
}
