using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.CreateCommand
{
    public class CreateHotelRoomHandler : IRequestHandler<CreateHotelRoomCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateHotelRoomHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateHotelRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                // Mapear y registrar el hotel
                var hotel = _mapper.Map<Entity.Hotel>(request);
                var hotelReg = await _unitOfWork.Hotel.RegisterHotel(hotel);

                // Insertar habitaciones
                foreach (var room in request.Rooms)
                {
                    var newRoom = new Entity.Room
                    {
                        HotelId = hotelReg.HotelId,
                        RoomTypeId = room.RoomTypeId,
                        Capacity = room.Capacity,
                        BaseCost = room.BaseCost,
                        Taxes = room.Taxes,
                        Location = room.Location
                    };

                    await _unitOfWork.Hotel.RegisterRoom(newRoom);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
