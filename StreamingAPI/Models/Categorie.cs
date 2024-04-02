namespace StreamingAPI.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? Category { get; set; }

        // Navigation property for the relationship with Anime
        public ICollection<Anime>? Animes { get; set; }


    }
}
