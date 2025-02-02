using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace HOTELBOOKING.Application.UseCase.UseCases.Hotel.Commands.ChangeStateCommand
{
    public class ChangeStateHotelHandler : IRequestHandler<ChangeStateHotelCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateHotelHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateHotelCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var hotel = _mapper.Map<Entity.Hotel>(request);
                var parameters = hotel.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Hotel.ExecAsync(SP.SP_HOTEL_CHANGE_STATE, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE_STATE;
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }

}
