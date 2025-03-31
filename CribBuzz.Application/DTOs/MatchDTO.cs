namespace CribBuzz.Application.DTOs;
public class MatchDTO 
{
    public int Id { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public DateTime MatchDate { get; set; }
    public string Venue { get; set; }
    public string Status { get; set; }
    public int? WinnerTeamId { get; set; }
}