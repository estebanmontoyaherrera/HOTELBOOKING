using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.ChangeStateCommand
{
    public class ChangeStateRoomHandler : IRequestHandler<ChangeStateRoomCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateRoomHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                // Mapeamos la solicitud al objeto Room en lugar de Hotel
                var room = _mapper.Map<Entity.Room>(request);
                var parameters = room.GetPropertiesWithValues();

                // Ejecutamos el procedimiento almacenado para la habitación (Room)
                response.Data = await _unitOfWork.Room.ExecAsync(SP.SP_ROOM_CHANGE_STATE, parameters);

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
