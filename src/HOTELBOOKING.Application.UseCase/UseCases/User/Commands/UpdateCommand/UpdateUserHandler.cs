using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using BC = BCrypt.Net.BCrypt;
using Entity = HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.UseCases.User.Commands.UpdateCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var user = _mapper.Map<Entity.User>(request);
                user.Password = BC.HashPassword(user.Password);
                var parameters = user.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_USER_UPDATE, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE;
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
