using AutoMapper;
using CompliantSystem.Dtos;
using CompliantSystem.Dtos.ComplaintDto;
using CompliantSystem.Models;

namespace CompliantSystem.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Complaint, ComplaintDto>();
            CreateMap<ComplaintDto, Complaint>();
        }
    }
}