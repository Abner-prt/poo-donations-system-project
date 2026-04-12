namespace donations_system_app.Entities;

// Este archivo esta incompleto y se deja asi por ahora solo para que compile
// la propiedad de navegacion de DonorEntity
public class DonationEntity
{
    public int Id { get; set; }
    public int DonorId { get; set; }
    public DonorEntity Donor { get; set; }
}
