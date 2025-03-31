using CribBuzz.Domain.Entities;
using CribBuzz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class TeamRepository : Repository<Team>, ITeamRepository

{
    private readonly CribBuzzDbContext _context;

    public TeamRepository(CribBuzzDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Team?> GetTeamWithPlayersAsync(int teamId)
    {
        return await _context.Teams
            .Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.Id == teamId);
    }

    public async Task<bool> TeamExistsAsync(string name)
    {
        return await _context.Teams.AnyAsync(t => t.Name == name);
    }
}