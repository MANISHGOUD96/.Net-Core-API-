using System.ComponentModel.DataAnnotations;

namespace Mk_Core_Web_API.DB_Connection
{
    public class Login
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
