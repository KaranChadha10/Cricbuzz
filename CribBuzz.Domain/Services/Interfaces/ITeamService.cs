using CribBuzz.Domain.Entities;
using CribBuzz.Common.Models.Responses;
namespace CribBuzz.Application.Services.Interfaces;
public interface ITeamService
{
    Task<PaginatedResponse<Team>> GetAllTeamsAsync(PaginationParam PaginationParam, CancellationToken cancellationToken = default);
    Task<Team> GetTeamByIdAsync(int teamId);
    Task<Team> CreateTeamAsync(Team team);  
    Task UpdateTeamAsync(Team team);
    Task DeleteTeamAsync(int teamId);
}