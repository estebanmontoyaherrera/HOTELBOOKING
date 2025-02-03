using Dapper;
using HOTELBOOKING.Application.Dtos.Reservation;
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
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllReservationResponseDto>> GetAllReservations(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            var reservations = await connection.QueryAsync<GetAllReservationResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return reservations;
        }

        public async Task<Reservation> RegisterReservation(Reservation reservation)
        {
            using var connection = _context.CreateConnection;
            var sql = @"
            INSERT INTO RESERVATIONS (ROOMID, USERID, CHECKINDATE, CHECKOUTDATE, GUESTCOUNT, CITYID, TOTALCOST, STATE, AUDITCREATEDATE)
            VALUES (@RoomId, @UserId, @CheckInDate, @CheckOutDate, @GuestCount, @CityId, @TotalCost, @State, @AuditCreateDate);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parameters = new DynamicParameters();
            parameters.Add("RoomId", reservation.RoomId);
            parameters.Add("UserId", reservation.UserId);
            parameters.Add("CheckInDate", reservation.CheckInDate);
            parameters.Add("CheckOutDate", reservation.CheckOutDate);
            parameters.Add("GuestCount", reservation.GuestCount);
            parameters.Add("CityId", reservation.CityId);
            parameters.Add("TotalCost", reservation.TotalCost);
            parameters.Add("State", 1); // Estado por defecto "Confirmada"
            parameters.Add("AuditCreateDate", DateTime.Now);

            var reservationId = await connection.QuerySingleOrDefaultAsync<int>(sql, parameters);
            reservation.ReservationId = reservationId;
            return reservation;
        }

        public async Task RegisterGuest(Guest guest)
        {
            using var connection = _context.CreateConnection;
            var sql = @"
            INSERT INTO GUESTS (RESERVATIONID, FIRSTNAME, LASTNAME, BIRTHDATE, GENDERID, DOCUMENTTYPEID, DOCUMENTNUMBER, EMAIL, PHONE)
            VALUES (@ReservationId, @FirstName, @LastName, @BirthDate, @GenderId, @DocumentTypeId, @DocumentNumber, @Email, @Phone);";

            var parameters = new DynamicParameters();
            parameters.Add("ReservationId", guest.ReservationId);
            parameters.Add("FirstName", guest.FirstName);
            parameters.Add("LastName", guest.LastName);
            parameters.Add("BirthDate", guest.BirthDate);
            parameters.Add("GenderId", guest.GenderId);
            parameters.Add("DocumentTypeId", guest.DocumentTypeId);
            parameters.Add("DocumentNumber", guest.DocumentNumber);
            parameters.Add("Email", guest.Email);
            parameters.Add("Phone", guest.Phone);

            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task RegisterEmergencyContact(EmergencyContact emergencyContact)
        {
            using var connection = _context.CreateConnection;
            var sql = @"
            INSERT INTO EMERGENCYCONTACTS (RESERVATIONID, FULLNAME, PHONE)
            VALUES (@ReservationId, @FullName, @Phone);";

            var parameters = new DynamicParameters();
            parameters.Add("ReservationId", emergencyContact.ReservationId);
            parameters.Add("FullName", emergencyContact.FullName);
            parameters.Add("Phone", emergencyContact.Phone);

            await connection.ExecuteAsync(sql, parameters);
        }
    }

}
