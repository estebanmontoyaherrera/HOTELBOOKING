using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace HOTELBOOKING.Application.UseCase.UseCases.User.Commands.ChangeStateCommand
{
    public class ChangeStateUserHandler : IRequestHandler<ChangeStateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(ChangeStateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var users = _mapper.Map<Entity.User>(request);
                var parameters = users.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_USER_CHANGE_STATE, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE_STATE;
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
