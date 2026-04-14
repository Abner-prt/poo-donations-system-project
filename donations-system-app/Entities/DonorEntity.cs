namespace donations_system_app.Entities;

public class DonorEntity
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 

    
    // Valores permitidos: 'Persona' o 'Empresa'
    public string Type { get; set; } 

    public DateTime RegisteredAt { get; set; } = DateTime.Now;

    // Propiedad de navegacion que permite que un mismo donante pueda tener varias donaciones
    public ICollection<DonationEntity> Donations { get; set; } = new List<DonationEntity>();
}
