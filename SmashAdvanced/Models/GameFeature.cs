using System.ComponentModel.DataAnnotations;

namespace SmashAdvanced.Models
{
    public class GameFeature
    {
        [Key]
        public int GameFeatureId { get; set; }
        public string GameFeatureText { get; set; } = string.Empty;
    }
}
