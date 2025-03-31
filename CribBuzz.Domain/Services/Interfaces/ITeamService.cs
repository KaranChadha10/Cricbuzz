using CribBuzz.Domain.Entities;
namespace CribBuzz.Application.Services.Interfaces;
public interface ITeamService
{
    Task<IEnumerable<Team>> GetAllTeamsAsync();
    Task<Team> GetTeamByIdAsync(int teamId);
    Task<Team> CreateTeamAsync(Team team);  
    Task UpdateTeamAsync(Team team);
    Task DeleteTeamAsync(int teamId);
}