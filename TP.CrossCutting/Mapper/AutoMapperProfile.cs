using AutoMapper;
using TP.Domain.Domain;
using TP.Domain.DTO.Student;

namespace TP.CrossCutting.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentRequestDTO, Student>().ReverseMap();
            CreateMap<StudentResponseDTO, Student>().ReverseMap();
        }
    }
}
