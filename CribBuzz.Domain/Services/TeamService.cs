using CribBuzz.Domain.Entities;
using CribBuzz.Common.Models.Responses;
using CribBuzz.Domain.Interfaces;

namespace CribBuzz.Application.Services.Interfaces;
public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPaginator<Team> _paginator;

    public TeamService(ITeamRepository teamRepository,  IPaginator<Team> paginator)
    {
        _teamRepository = teamRepository;
        _paginator = paginator;
    }

    public async Task<PaginatedResponse<Team>> GetAllTeamsAsync(
            PaginationParam paginationParams, CancellationToken cancellationToken = default)
        {
            var query = _teamRepository.GetAllTeamsWithPlayers();
            return await _paginator.PaginateAsync(
                query,
                paginationParams.pageNumber,
                paginationParams.pageSize,
                cancellationToken);
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