using CribBuzz.Domain.Entities;
using CribBuzz.Infrastructure.Repositories.Interfaces;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team?> GetTeamWithPlayersAsync(int teamId);
    
}