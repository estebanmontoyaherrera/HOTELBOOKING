using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HOTELBOOKING.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRoleRepository Role { get; }
        public IUserRepository User { get; }
        public ICityRepository City { get; }
        public IHotelRepository Hotel { get; }

        public IRoomTypeRepository RoomType { get; }

        public IRoomRepository Room { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
           
            _context = context;
            Role = new RoleRepository(_context);
            User = new UserRepository(_context);
            City = new CityRepository(_context);
            Hotel = new HotelRepository(_context);
            RoomType = new RoomTypeRepository(_context);
            Room = new RoomRepository(_context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TransactionScope BeginTransaction()
        {
            var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            return transaction;

        }
    }
}
