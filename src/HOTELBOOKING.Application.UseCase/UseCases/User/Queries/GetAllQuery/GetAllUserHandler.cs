using HOTELBOOKING.Application.Dtos.User.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.User.Queries.GetAllQuery
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, BaseResponse<IEnumerable<GetAllUserResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<IEnumerable<GetAllUserResponseDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllUserResponseDto>>();

            try
            {

                var user = await _unitOfWork.User.GetAllUsers(SP.SP_USER_LIST);

                if (user is not null)
                {
                    response.IsSuccess = true;
                    response.Data = user;
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
