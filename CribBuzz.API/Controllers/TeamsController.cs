using CribBuzz.Application.Services.Interfaces;
using CribBuzz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;
    private readonly ILogger<TeamsController> _logger;
    public TeamsController(ITeamService teamService, ILogger<TeamsController> logger)
    {
        _teamService = teamService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        try
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving  all teams");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(int id)
    {
        try
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound($"Team with ID {id} not found.");
            }
            return Ok(team);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving team with ID {id}");
            return StatusCode(500, "Internal server error");
        }
    }


    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] Team team)
    {
        try
        {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
           var createdTeam = await _teamService.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetTeamById), new { id = createdTeam.Id }, createdTeam);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Team creation failed due to invalid data");
            return BadRequest(ex.Message);
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, "Error creating team");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeam(int id, [FromBody] Team team)
    {
        try
        {
            if(id != team.Id)
            {
                return BadRequest("Team ID mismatch.");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _teamService.UpdateTeamAsync(team);
            return NoContent();
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, $"Error updating team with ID {id}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        try
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting team with ID {id}");
            return StatusCode(500, "Internal server error");
        }
    }
}