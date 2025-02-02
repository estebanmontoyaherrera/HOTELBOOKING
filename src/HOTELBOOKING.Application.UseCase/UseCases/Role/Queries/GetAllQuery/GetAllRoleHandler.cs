using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;

namespace HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetAllQuery
{
    public class GetAllRoleHandler : IRequestHandler<GetAllRoleQuery, BaseResponse<IEnumerable<GetAllRoleResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllRoleResponseDto>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllRoleResponseDto>>();

            try
            {

                var roles = await _unitOfWork.Role.GetAllRoles(SP.SP_ROLE_LIST);

                if (roles is not null)
                {
                    response.IsSuccess = true;
                    response.Data = roles;
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
