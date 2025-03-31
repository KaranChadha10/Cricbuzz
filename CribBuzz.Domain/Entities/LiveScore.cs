namespace CribBuzz.Domain.Entities;
using System.Collections.Generic;
public class LiveScore
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public int TeamId { get; set; }
    public int Runs { get; set; }   
    public int wickets { get; set; } // wickets lost
    public double Overs { get; set; } // overs bowled
    public double RunRate { get; set; } // current run rate

    //Navigation properites
    public Match Match {get; set; }
    public Team Team { get; set;}
}