using AutoMapper;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.User.Commands.UpdateCommand;
using HOTELBOOKING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.Mappings
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
           
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<ChangeStateUserCommand, User>();


        }
    }
}
