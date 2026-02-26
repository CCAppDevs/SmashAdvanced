namespace SmashAdvanced.Models
{
    public class GameTag
    {
        public int GameTagId { get; set; }
        public int GameId { get; set; }
        public int TagId { get; set; }

        public Game Game { get; set; }
        public Tag Tag { get; set; }
    }
}
