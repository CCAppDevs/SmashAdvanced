using System.ComponentModel.DataAnnotations;

namespace SmashAdvanced.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public double RetailPrice { get; set; }
        public string DownloadUrl { get; set; } = string.Empty;
        public DateOnly LastUpdated { get; set; }
        public string ReleaseStatus { get; set; } = string.Empty;
        public GameScreenshot TitleImage { get; set; }

        public ICollection<GameTag> GameTags { get; set; } = new List<GameTag>();
        public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();
        public ICollection<GameFeature> GameFeatures { get; set; } = new List<GameFeature>();
        public ICollection<GameScreenshot> GameScreenshots { get; set; } = new List<GameScreenshot>();
    }
}
