using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUD.Models
{
    [Table("user_details")]
    public class User
    {
        [Column("user_id")]
        [Key]
        public int userId { get; set; }

        [MaxLength(100)]
        [Column("username")]
        public string? UserName { get; set; }

        [MaxLength(100)]
        [Column("address")]
        public string? Address { get; set; }
        
        [MaxLength(50)]
        [Column("cell_number")]
        public string? CellNumber { get; set; }

        [MaxLength(50)]
        [Column("user_email")]
        public string? Email { get; set; }
    }
}
