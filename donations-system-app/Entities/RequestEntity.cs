namespace donations_system_app.Entities;

public class RequestEntity
{
    public int Id { get; set; }

    // Nombre de la institucion que solicita
    public string InstitutionName { get; set; } 

    // Descripcion de la necesidad
    public string Description { get; set; }

    // Tipo de necesidad: 'Money' o 'Item'
    public string NeedType { get; set; }

    // Cantidad solicitada
    public double RequestedQuantity { get; set; }

    // Estado de la solicitud: 'Pending' o 'Completed'
    public string Status { get; set; }

    // Fecha de la solicitud
    public DateTime Date { get; set; }
}
