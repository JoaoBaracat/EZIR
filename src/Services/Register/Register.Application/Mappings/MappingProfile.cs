using AutoMapper;
using Register.Application.ViewModels;
using Register.Domain.Entities;

namespace Register.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Operation, OperationVm>().ReverseMap();
        }
    }
}