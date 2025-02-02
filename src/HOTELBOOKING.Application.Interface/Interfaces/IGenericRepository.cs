using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllASync(string storedProcedure);
        Task<T> GetByIdAsync(string storedProcedure, object parameter);
        Task<bool> ExecAsync(string storedProcedure, object parameter);

        Task<IEnumerable<T>> GetAllWithPaginationAsync(string storedProcedure, object parameter);
        Task<int> CountAsync(string tableName);

    }
}
