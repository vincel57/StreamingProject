using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StreamingAPI.Models
{
    public class Client
    {

        public int Id { get; set; }
        
        public string? Nom { get; set; }
        [Required]
        
        public string? Surname { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        //ceci représente une relation mamy to many
        public ICollection<Anime>? SubscribedAnimes { get; set; }





    }
}
