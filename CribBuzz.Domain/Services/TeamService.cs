using CribBuzz.Domain.Entities;
namespace CribBuzz.Application.Services.Interfaces;
public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    public TeamService(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await _teamRepository.GetAllAsync();
    }

    public async Task<Team> GetTeamByIdAsync(int teamId)
    {
        return await _teamRepository.GetTeamWithPlayersAsync(teamId);
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        if(await _teamRepository.TeamExistsAsync(team.Name))
        {
            throw new Exception($"Team with name {team.Name} already exists.");
        }
        await _teamRepository.AddAync(team);
        await _teamRepository.SaveChangesAsync();
        return team;
    }

     public async Task UpdateTeamAsync(Team team)
    {
        _teamRepository.UpdateAsync(team);
        await _teamRepository.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(int teamId)
    {
        var team = await _teamRepository.GetByIdAsync(teamId);
        if (team != null)
        {
            _teamRepository.Delete(team);
            await _teamRepository.SaveChangesAsync();
        }
    }

}