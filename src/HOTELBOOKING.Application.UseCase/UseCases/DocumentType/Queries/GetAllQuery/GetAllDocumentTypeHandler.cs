using HOTELBOOKING.Application.Dtos.DocumentType;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.UseCase.UseCases.DocumentType.Queries.GetAllQuery
{
    public class GetAllDocumentTypeHandler : IRequestHandler<GetAllDocumentTypeQuery, BaseResponse<IEnumerable<GetAllDocumentTypeResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDocumentTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllDocumentTypeResponseDto>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllDocumentTypeResponseDto>>();

            try
            {
                // Llamada al repositorio para obtener todos los tipos de documento
                var documentTypes = await _unitOfWork.DocumentType.GetAllDocumentTypes(SP.SP_DOCUMENTTYPE_LIST);

                if (documentTypes is not null)
                {
                    response.IsSuccess = true;
                    response.Data = documentTypes;
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
