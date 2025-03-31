namespace CribBuzz.Domain.Entities;
using System.Collections.Generic;
public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TeamId { get; set; }
    public string Role { get; set; } // batsman, bowler, all-rounder, wicket-keeper

    //Navigation Properties
    public Team Team { get; set; } // This is the team that the player belongs to
}