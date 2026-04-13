using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donations_system_app.Entities
{
    [Table("requests")]
    public class RequestEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        // Nombre de la institucion que solicita
        [Required]
        [StringLength(100)]
        [Column("institution_name")]
        public string InstitutionName { get; set; }

        // Descripcion de la necesidad
        [StringLength(500)]
        [Column("description")]
        public string Description { get; set; }

        // Tipo de necesidad: 'Money' o 'Item'
        [Required]
        [StringLength(20)]
        [Column("need_type")]
        public string NeedType { get; set; }

        // Cantidad solicitada
        [Column("requested_quantity")]
        public decimal RequestedQuantity { get; set; }

        // Estado de la solicitud: 'Pending' o 'Completed'
        [Required]
        [StringLength(20)]
        [Column("status")]
        public string Status { get; set; }

        // Fecha de la solicitud
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
