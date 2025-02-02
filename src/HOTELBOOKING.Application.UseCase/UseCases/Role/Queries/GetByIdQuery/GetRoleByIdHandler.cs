using AutoMapper;
using HOTELBOOKING.Application.Dtos.Role.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Role.Queries.GetByIdQuery
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, BaseResponse<GetRoleByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetRoleByIdResponseDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetRoleByIdResponseDto>();

            try
            {
                var roles = await _unitOfWork.Role.GetByIdAsync(SP.SP_ROLE_BY_ID, request);

                if (roles is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetRoleByIdResponseDto>(roles);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
