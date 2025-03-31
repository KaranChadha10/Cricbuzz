namespace CribBuzz.Domain.Entities;
public class Commentary
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int BatsmanId { get; set; }
    public int BowlerId { get; set; }
    public int RunsScored { get; set; } // runs scored in the ball
    public string Description { get; set; } // description of the ball (e.g. "4 runs", "Wicket", "1 run")
    public DateTime Timestamp { get; set; } // timestamp of the ball

    //Navigation Properties 
    public Match Match { get; set; } // This is the match that the commentary belongs to
    public Player Batsman { get; set; } // This is the batsman who faced the ball
    public Player Bowler { get; set; } // This is the bowler who bowled the ball
}