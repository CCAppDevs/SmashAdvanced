using System.ComponentModel.DataAnnotations;

namespace SmashAdvanced.Models
{
    public class GamePlatform
    {
        [Key]
        public int GamePlatformId { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }
}
