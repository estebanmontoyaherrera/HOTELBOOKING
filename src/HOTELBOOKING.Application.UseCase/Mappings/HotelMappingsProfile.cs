using AutoMapper;
using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand;
using HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.UpdateCommand;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.Mappings
{
    public class HotelMappingsProfile : Profile
    {
        public HotelMappingsProfile()
        {
            CreateMap<GetHotelByIdResponseDto, Hotel>()
             .ReverseMap();

            CreateMap<GetRoomByHotelIdResponseDto, Room>()
                .ReverseMap();

            CreateMap<CreateHotelCommand, Hotel>();
            CreateMap<CreateHotelRoomCommand, Hotel>();
            CreateMap<CreateRoomsCommand, Room>();
            CreateMap<UpdateHotelCommand, Hotel>();
            CreateMap<ChangeStateHotelCommand, Hotel>();


        }
    }
}
