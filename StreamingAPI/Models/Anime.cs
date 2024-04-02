using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingAPI.Models
{
    public class Anime
    {

        public int Id { get; set; }

        public string? Name { get; set; }
        [Required]

        public string? Description { get; set; }
        [Required]
        public string? Link_image { get; set; }
        [Required]
        public string?Link_video { get; set; }
        [ForeignKey("FK_categorie_Anime")]
        public int CategorieId { get; set; }





    }
}
