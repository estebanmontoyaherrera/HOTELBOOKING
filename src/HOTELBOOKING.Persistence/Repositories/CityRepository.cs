using Dapper;
using HOTELBOOKING.Application.Dtos.City.Response;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;

        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllCityResponseDto>> GetAllCities(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var cities = await connection.QueryAsync<GetAllCityResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return cities;
        }
    }

}
