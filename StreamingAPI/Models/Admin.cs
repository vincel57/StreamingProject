using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Models
{
    public class Admin
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? telephone { get; set; }

        // Toutv se passe vbien 

    }
}
