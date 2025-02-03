using AutoMapper;
using HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.Mappings
{
    public class ReservationMappingsProfile : Profile
    {
        public ReservationMappingsProfile()
        {
            CreateMap<CreateReservationCommand, Reservation>()
            .ReverseMap();
            CreateMap<CreateGuestCommand, Guest>()
            .ReverseMap();
            CreateMap<CreateEmergencyContactCommand, EmergencyContact>()
            .ReverseMap();
        }
    }
}
