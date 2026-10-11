using System.ComponentModel.DataAnnotations;

namespace MarvelHerosAPI.DataModel
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public required string HeroName { get; set; }
        public int UniverseNumber { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string OwnedBy { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
