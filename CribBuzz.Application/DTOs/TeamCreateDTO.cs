public class TeamCreateDTO {
    public string Name { get; set; }
    public string ShortName { get; set; }
    public List<PlayerCreateDTO> Players { get; set; } = new();
}