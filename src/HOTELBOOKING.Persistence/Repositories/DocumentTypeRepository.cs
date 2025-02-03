using Dapper;
using HOTELBOOKING.Application.Dtos.DocumentType;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllDocumentTypeResponseDto>> GetAllDocumentTypes(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var documentTypes = await connection.QueryAsync<GetAllDocumentTypeResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return documentTypes;
        }
    }

}
