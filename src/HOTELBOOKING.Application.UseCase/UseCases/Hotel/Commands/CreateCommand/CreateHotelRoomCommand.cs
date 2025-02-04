using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand
{
    public class CreateHotelRoomCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? CityId { get; set; }
        public string? CommissionRate { get; set; }

        public IEnumerable<CreateRoomsCommand>? Rooms { get; set; } = null!;
    }

    public class CreateRoomsCommand
    {
        public int RoomTypeId { get; set; }
        public int Capacity { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string Location { get; set; } = null!;
    }
}
