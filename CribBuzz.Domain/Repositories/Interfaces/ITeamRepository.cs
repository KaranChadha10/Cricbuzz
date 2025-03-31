using CribBuzz.Domain.Entities;
using CribBuzz.Domain.Repositories.Interfaces;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team?> GetTeamWithPlayersAsync(int teamId);
    
}