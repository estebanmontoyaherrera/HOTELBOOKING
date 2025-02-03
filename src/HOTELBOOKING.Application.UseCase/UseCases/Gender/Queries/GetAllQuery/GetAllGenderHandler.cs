using HOTELBOOKING.Application.Dtos.Gender;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.Gender.Queries.GetAllQuery
{
    public class GetAllGenderHandler : IRequestHandler<GetAllGenderQuery, BaseResponse<IEnumerable<GetAllGenderResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGenderHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllGenderResponseDto>>> Handle(GetAllGenderQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllGenderResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todos los géneros
                var genders = await _unitOfWork.Gender.GetAllGenders(SP.SP_GENDER_LIST);

                if (genders is not null)
                {
                    response.IsSuccess = true;
                    response.Data = genders;
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
