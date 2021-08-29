using AutoMapper;
using Register.Application.Features.Operations.Commands.CreateOperation;
using Register.Application.Features.Operations.Commands.UpdateOperation;
using Register.Application.Features.OperationTypes.Commands.CreateOperationType;
using Register.Application.Features.OperationTypes.Commands.UpdateOperationType;
using Register.Application.ViewModels;
using Register.Domain.Entities;

namespace Register.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Operation, OperationVm>().ReverseMap();
            CreateMap<Operation, CreateOperationCommand>().ReverseMap();
            CreateMap<Operation, UpdateOperationCommand>().ReverseMap();

            CreateMap<OperationType, OperationTypeVm>().ReverseMap();
            CreateMap<OperationType, CreateOperationTypeCommand>().ReverseMap();
            CreateMap<OperationType, UpdateOperationTypeCommand>().ReverseMap();
        }
    }
}