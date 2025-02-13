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

        //  método para calcular el costo total de la reserva
        Task<decimal> CalculateTotalReservationCost(int roomId, DateTime checkInDate, DateTime checkOutDate);
    }
}
