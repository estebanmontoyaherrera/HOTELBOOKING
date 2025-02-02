using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using HOTELBOOKING.Utilities.HelperExtensions;
using MediatR;
using BC = BCrypt.Net.BCrypt;
using Entity = HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.UseCases.User.Commands.CreateCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var user = _mapper.Map<Entity.User>(request);
                user.Password = BC.HashPassword(user.Password);
                var parameters = user.GetPropertiesWithValues();
                response.Data = await _unitOfWork.User.ExecAsync(SP.SP_USER_CREATE, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
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
