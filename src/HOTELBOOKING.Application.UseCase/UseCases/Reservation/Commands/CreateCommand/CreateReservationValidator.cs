using FluentValidation;

namespace HOTELBOOKING.Application.UseCase.UseCases.Reservation.Commands.CreateCommand
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationValidator()
        {
            // Validar RoomId
            RuleFor(x => x.RoomId)
                .NotNull().WithMessage("El ID de la habitación es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la habitación debe ser mayor a 0.");

            // Validar UserId
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("El ID del usuario debe ser mayor a 0.");

            // Validar CheckInDate (Debe ser en el futuro)
            RuleFor(x => x.CheckInDate)
                .NotNull().WithMessage("La fecha de check-in es obligatoria.")
                .GreaterThan(DateTime.UtcNow).WithMessage("La fecha de check-in debe ser en el futuro.");

            // Validar CheckOutDate (Debe ser después de CheckInDate)
            RuleFor(x => x.CheckOutDate)
                .NotNull().WithMessage("La fecha de check-out es obligatoria.")
                .GreaterThan(x => x.CheckInDate)
                .WithMessage("La fecha de check-out debe ser posterior a la fecha de check-in.");

            // Validar HotelName
            RuleFor(x => x.HotelName)
                .NotNull().WithMessage("El nombre del hotel no puede ser nulo.")
                .NotEmpty().WithMessage("El nombre del hotel no puede estar vacío.");

            // Validar que haya al menos un huésped
            RuleFor(x => x.Guests)
                .NotNull().WithMessage("Debe haber al menos un huésped.")
                .Must(x => x != null && x.Any()).WithMessage("Debe haber al menos un huésped.");

            // Validar datos de cada huésped
            RuleForEach(x => x.Guests).ChildRules(guest =>
            {
                guest.RuleFor(g => g.FirstName)
                    .NotEmpty().WithMessage("El nombre del huésped es obligatorio.");

                guest.RuleFor(g => g.LastName)
                    .NotEmpty().WithMessage("El apellido del huésped es obligatorio.");

                guest.RuleFor(g => g.DocumentNumber)
                    .NotEmpty().WithMessage("El número de documento es obligatorio.")
                    .Matches(@"^\d+$").WithMessage("El número de documento debe contener solo números.");

                guest.RuleFor(g => g.Email)
                    .NotEmpty().WithMessage("El correo del huésped es obligatorio.")
                    .EmailAddress().WithMessage("El correo del huésped debe ser válido.");
            });

            // Validar contacto de emergencia (si se envía)
            RuleFor(x => x.EmergencyContact).ChildRules(contact =>
            {
                contact.RuleFor(c => c.FullName)
                    .NotEmpty().WithMessage("El nombre del contacto de emergencia es obligatorio.");

                contact.RuleFor(c => c.Phone)
                    .NotEmpty().WithMessage("El teléfono del contacto de emergencia es obligatorio.")
                    .Matches(@"^\d+$").WithMessage("El teléfono debe contener solo números.");
            });
        }
    }
}
