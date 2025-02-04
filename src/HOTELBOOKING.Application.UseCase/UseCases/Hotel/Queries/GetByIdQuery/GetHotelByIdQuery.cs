using HOTELBOOKING.Application.Dtos.Hotel.Response;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Queries.GetByIdQuery
{
    public class GetHotelByIdQuery : IRequest<BaseResponse<GetHotelByIdResponseDto>>
    {
        public int HotelId { get; set; }
    }

}
