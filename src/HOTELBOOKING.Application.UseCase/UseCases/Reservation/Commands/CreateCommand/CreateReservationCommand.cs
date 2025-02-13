using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand
{
    public class CreateReservationCommand : IRequest<BaseResponse<bool>>
    {
        public int? RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
         public int? numGuests { get; set; }
        public string? HotelName { get; set; } 
        public IEnumerable<CreateGuestCommand>? Guests { get; set; } = null!;
        public CreateEmergencyContactCommand? EmergencyContact { get; set; } = null!;
    }

    public class CreateGuestCommand
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public DateTime? BirthDate { get; set; }
        public int? GenderId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class CreateEmergencyContactCommand
    {
        public string? FullName { get; set; } = null!;
        public string? Phone { get; set; } = null!;
    }

}
