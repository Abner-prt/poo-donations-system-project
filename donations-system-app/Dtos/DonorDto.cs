namespace donations_system_app.Dtos;

public class DonorDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Type { get; set; } // 'Person' or 'Company'
}
