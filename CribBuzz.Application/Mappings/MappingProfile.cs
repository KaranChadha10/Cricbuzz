using AutoMapper;
using CribBuzz.Application.DTOs;
using CribBuzz.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Match, MatchDTO>().ReverseMap();
        CreateMap<Team, TeamDTO>().ReverseMap();
        CreateMap<Player, PlayerDTO>().ReverseMap();
    }
}