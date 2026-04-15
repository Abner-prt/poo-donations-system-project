namespace donations_system_app.Dtos.Requests
{
    // Dto para registrar una nueva solicitud
    public class RequestDto
    {
        public string InstitutionName { get; set; }
        public string Description { get; set; }
        public string NeedType { get; set; }
        public decimal RequestedQuantity { get; set; }
    }
}
