using AutoMapper;
using HOTELBOOKING.Application.Interface.Interfaces;
using HOTELBOOKING.Application.UseCase.Commons.Bases;
using HOTELBOOKING.Domain.Entities;
using HOTELBOOKING.Utilities.Constants;
using MediatR;
using Entity = HOTELBOOKING.Domain.Entities;
namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReservationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                // Mapear y registrar la reserva
                var reservation = _mapper.Map<Entity.Reservation>(request);
                var reservationReg = await _unitOfWork.Reservation.RegisterReservation(reservation);

                // Insertar huéspedes
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
                //response.Data =reservationReg.ReservationId>0;
                response.Message = GlobalMessages.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
