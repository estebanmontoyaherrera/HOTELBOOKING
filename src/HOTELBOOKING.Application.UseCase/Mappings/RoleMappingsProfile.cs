using AutoMapper;
using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.Mappings
{
    public class RoleMappingsProfile : Profile
    {
        public RoleMappingsProfile()
        {
            CreateMap<Role, GetRoleByIdResponseDto>()
            .ReverseMap();

           
        }
    }
}
