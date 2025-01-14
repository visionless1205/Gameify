using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Gameify.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Display(Name = "Game Name")]
        public string Game_Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int? DeveloperID { get; set; }
        public Developer? DeveloperName { get; set; }
        public int? PlatformID { get; set; } // Foreign key for Platform
        [ForeignKey("PlatformID")]
        public Platform? Platform { get; set; }



        public string Game_Genre {  get; set; }
    }
}
