using HOTELBOOKING.Application.Dtos.RoomType.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.RoomType.GetAllQuery
{
    public class GetAllRoomTypeHandler : IRequestHandler<GetAllRoomTypeQuery, BaseResponse<IEnumerable<GetAllRoomTypeResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoomTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllRoomTypeResponseDto>>> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllRoomTypeResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todos los tipos de habitaciones (Room Types)
                var roomTypes = await _unitOfWork.RoomType.GetAllRoomTypes(SP.SP_ROOMTYPE_LIST);

                if (roomTypes is not null)
                {
                    response.IsSuccess = true;
                    response.Data = roomTypes;
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
