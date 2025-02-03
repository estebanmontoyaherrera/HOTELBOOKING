using HOTELBOOKING.Application.Dtos.Reservation;
using HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.Interface.Interfaces
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<GetAllReservationResponseDto>> GetAllReservations(string storedProcedure);
        Task<Reservation> RegisterReservation(Reservation reservation);
        Task RegisterGuest(Guest guest);
        Task RegisterEmergencyContact(EmergencyContact emergencyContact);
    }
}
