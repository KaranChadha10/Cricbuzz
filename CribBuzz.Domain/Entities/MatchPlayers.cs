namespace CribBuzz.Domain.Entities
{
    public class MatchPlayers
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsWicketKeeper { get; set; }

        // Navigation Properties
        public Match Match { get; set; }
        public Player Player { get; set; }
    }
}