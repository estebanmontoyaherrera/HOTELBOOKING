using HOTELBOOKING.Application.Dtos.DocumentType;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IDocumentTypeRepository : IGenericRepository<DocumentType>
    {
        Task<IEnumerable<GetAllDocumentTypeResponseDto>> GetAllDocumentTypes(string storedProcedure);
    }
}
