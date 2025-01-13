namespace Gameify.Models
{
    public class Developer
    {
        public int ID { get; set; }
        public string DeveloperName { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
