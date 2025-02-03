using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRoleRepository Role { get; }
        IUserRepository User { get; }
        ICityRepository City { get; }
        IHotelRepository Hotel { get; }
        IRoomTypeRepository RoomType { get; }
        IRoomRepository Room { get; }
        IReservationRepository Reservation { get; }
        IDocumentTypeRepository DocumentType { get; }
        IGenderRepository Gender { get; }
        TransactionScope BeginTransaction();
    }
}
