using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUD.Models
{
    [Table("user_registration")]
    public class RegistrationModel
    {
        [Column("user_id")]
        [Key]
        public string? UserId { get; set; } 
        [MaxLength(100)]
        [Column("user_name")]
        public string? UserName { get; set; }
        [MaxLength(500)]
        [Column("address")]
        public string? Address { get; set; }
        [MaxLength(50)]
        [Column("cell_number")]
        public string? CellNumber { get; set; }
        [MaxLength(50)]
        [Column("email_id")]
        public string? EmailId { get; set; }
    }
}
