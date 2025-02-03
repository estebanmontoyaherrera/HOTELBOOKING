using HOTELBOOKING.Application.Dtos.Gender;
using HOTELBOOKING.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IGenderRepository : IGenericRepository<Gender>
    {
        Task<IEnumerable<GetAllGenderResponseDto>> GetAllGenders(string storedProcedure);
    }

}
