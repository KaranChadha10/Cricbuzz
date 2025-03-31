namespace CribBuzz.Domain.Entities;
public class Team
{
    public int Id {get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public ICollection<Player> Players { get; set; }
}