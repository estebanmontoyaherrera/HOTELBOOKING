using HOTELBOOKING.Application.Dtos.Room.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Queries.GetAllQuery
{
    public class GetAllRoomHandler : IRequestHandler<GetAllRoomQuery, BaseResponse<IEnumerable<GetAllRoomResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoomHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllRoomResponseDto>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllRoomResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todas las habitaciones (Rooms)
                var rooms = await _unitOfWork.Room.GetAllRooms(SP.SP_ROOM_LIST);

                if (rooms is not null)
                {
                    response.IsSuccess = true;
                    response.Data = rooms;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
