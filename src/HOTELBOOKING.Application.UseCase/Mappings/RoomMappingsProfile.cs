using AutoMapper;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.UpdateCommand;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.Mappings
{
    public class RoomMappingsProfile : Profile
    {
        public RoomMappingsProfile()
        {
            CreateMap<CreateRoomCommand, Room>();
            CreateMap<UpdateRoomCommand, Room>();
            CreateMap<ChangeStateRoomCommand, Room>();

        }
    }
}
