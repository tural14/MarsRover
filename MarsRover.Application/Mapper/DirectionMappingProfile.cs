using AutoMapper;
using MarsRover.Application.Common;

namespace MarsRover.Application.Mapper
{
    public class DirectionMappingProfile : Profile
    {
        public DirectionMappingProfile()
        {
            CreateMap<Directions, Domain.Directions>().ReverseMap();
        }
    }
}
