using HOTELBOOKING.Application.Dtos.City.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.City.GetAllQuery
{
    public class GetAllCityHandler : IRequestHandler<GetAllCityQuery, BaseResponse<IEnumerable<GetAllCityResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllCityResponseDto>>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllCityResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todas las ciudades
                var cities = await _unitOfWork.City.GetAllCities(SP.SP_CITY_LIST);

                if (cities is not null)
                {
                    response.IsSuccess = true;
                    response.Data = cities;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
