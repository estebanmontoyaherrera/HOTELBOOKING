using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.Interface.Services;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entity = HOTELBOOKING.Domain.Entities;

namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateReservationHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<BaseResponse<bool>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                // Validar que RoomId tenga un valor
                if (request.RoomId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "La habitación es obligatoria.";
                    return response;
                }

                // Obtener nombre del hotel desde la solicitud
                string hotelName = request.HotelName ?? "Hotel Desconocido";

                // Registrar la reserva
                var reservation = _mapper.Map<Entity.Reservation>(request);
                var reservationReg = await _unitOfWork.Reservation.RegisterReservation(reservation);

                // Insertar huéspedes
                if (request.Guests != null && request.Guests.Any())
                {
                    foreach (var guest in request.Guests)
                    {
                        var newGuest = new Guest
                        {
                            ReservationId = reservationReg.ReservationId,
                            FirstName = guest.FirstName,
                            LastName = guest.LastName,
                            BirthDate = guest.BirthDate,
                            GenderId = guest.GenderId,
                            DocumentTypeId = guest.DocumentTypeId,
                            DocumentNumber = guest.DocumentNumber,
                            Email = guest.Email,
                            Phone = guest.Phone
                        };

                        await _unitOfWork.Reservation.RegisterGuest(newGuest);
                    }
                }

                // Insertar contacto de emergencia
                if (request.EmergencyContact != null)
                {
                    var emergencyContact = new EmergencyContact
                    {
                        ReservationId = reservationReg.ReservationId,
                        FullName = request.EmergencyContact.FullName,
                        Phone = request.EmergencyContact.Phone
                    };

                    await _unitOfWork.Reservation.RegisterEmergencyContact(emergencyContact);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_SAVE;

                // Enviar correo de confirmación a todos los huéspedes
                if (request.Guests != null && request.Guests.Any())
                {
                    string subject = "Confirmación de Reserva";

                    foreach (var guest in request.Guests)
                    {
                        if (!string.IsNullOrEmpty(guest.Email))
                        {
                            string body = $@"
                                <h2>Reserva Confirmada</h2>
                                <p>Estimado/a {guest.FirstName},</p>
                                <p>Su reserva en el hotel <strong>{hotelName}</strong> ha sido confirmada.</p>
                                <p><strong>Fecha de entrada:</strong> {request.CheckInDate}</p>
                                <p><strong>Fecha de salida:</strong> {request.CheckOutDate}</p>
                               
                                <p>Gracias por elegirnos.</p>";

                            await _emailService.SendEmailAsync(guest.Email, subject, body);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
