using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace RoomBOOKING.Application.UseCase.UseCases.Room.Commands.CreateCommand
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var Room = _mapper.Map<Entity.Room>(request);
                var parameters = Room.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Room.ExecAsync(SP.SP_ROOM_CREATE, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE;
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
