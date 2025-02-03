using Dapper;
using HOTELBOOKING.Application.Dtos.Reservation;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Persistence.Context;
using System.Data;

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

            // 1. Verificar que la fecha de CheckIn no sea menor al día de hoy
            if (reservation.CheckInDate < DateTime.Now.Date)
            {
                throw new InvalidOperationException("La fecha de entrada no puede ser menor a la fecha actual.");
            }

            // 2. Verificar que la fecha de CheckOut sea al menos un día después de CheckIn
            if (reservation.CheckOutDate <= reservation.CheckInDate)
            {
                throw new InvalidOperationException("La fecha de salida debe ser al menos un día después de la fecha de entrada.");
            }

            // 3. Verificar la disponibilidad de las fechas
            var availabilitySql = @"SELECT COUNT(*)
                            FROM RESERVATIONS R
                            WHERE R.ROOMID = @RoomId
                            AND ((R.CHECKINDATE <= @CheckOutDate AND R.CHECKOUTDATE >= @CheckInDate));";

            var availabilityParams = new DynamicParameters();
            availabilityParams.Add("RoomId", reservation.RoomId);
            availabilityParams.Add("CheckInDate", reservation.CheckInDate);
            availabilityParams.Add("CheckOutDate", reservation.CheckOutDate);

            var existingReservationsCount = await connection.QuerySingleOrDefaultAsync<int>(availabilitySql, availabilityParams);
            if (existingReservationsCount > 0)
            {
                throw new InvalidOperationException("La habitación no está disponible en las fechas seleccionadas.");
            }

            // 4. Insertar la reserva
            var sql = @"INSERT INTO RESERVATIONS (ROOMID, USERID, CHECKINDATE, CHECKOUTDATE, STATE, AUDITCREATEDATE)
                VALUES (@RoomId, @UserId, @CheckInDate, @CheckOutDate, @State, @AuditCreateDate);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            var parameters = new DynamicParameters();
            parameters.Add("RoomId", reservation.RoomId);
            parameters.Add("UserId", reservation.UserId);
            parameters.Add("CheckInDate", reservation.CheckInDate);
            parameters.Add("CheckOutDate", reservation.CheckOutDate);
            parameters.Add("State", 1); // Estado por defecto "Confirmada"
            parameters.Add("AuditCreateDate", DateTime.Now);

            // Ejecutar la consulta e insertar la reserva
            var reservationId = await connection.QuerySingleOrDefaultAsync<int>(sql, parameters);

            // Asignar el ID de la reserva al objeto y devolverlo
            reservation.ReservationId = reservationId;
            return reservation;
        }
        public async Task RegisterGuest(Guest guest)
        {
            using var connection = _context.CreateConnection;

            // 1. Verificar la capacidad total de la habitación
            var capacitySql = @"SELECT RM.CAPACITY
                        FROM ROOMS RM
                        INNER JOIN RESERVATIONS R ON RM.ROOMID = R.ROOMID
                        WHERE R.RESERVATIONID = @ReservationId;";

            var capacityParams = new DynamicParameters();
            capacityParams.Add("ReservationId", guest.ReservationId);

            var roomCapacity = await connection.QuerySingleOrDefaultAsync<int>(capacitySql, capacityParams);

            // 2. Verificar el número de huéspedes ya registrados para esta reserva
            var currentGuestCountSql = @"SELECT COUNT(*)
                                 FROM GUESTS G
                                 WHERE G.RESERVATIONID = @ReservationId;";

            var currentGuestCount = await connection.QuerySingleOrDefaultAsync<int>(currentGuestCountSql, capacityParams);

            // Verificar si se supera la capacidad de la habitación
            if (currentGuestCount >= roomCapacity)
            {
                throw new InvalidOperationException($"La capacidad máxima de la habitación es de {roomCapacity} personas. No se pueden registrar más huéspedes.");
            }

            // 3. Registrar el nuevo huésped
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
